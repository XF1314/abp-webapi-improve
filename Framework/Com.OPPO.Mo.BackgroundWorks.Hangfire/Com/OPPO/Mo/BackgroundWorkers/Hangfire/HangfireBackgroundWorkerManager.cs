using Com.OPPO.Mo.Extensions;
using Hangfire;
using Hangfire.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.DependencyInjection;

namespace Com.OPPO.Mo.BackgroundWorkers.Hangfire
{
    [Dependency(ReplaceServices = true)]
    public class HangfireBackgroundWorkerManager : IBackgroundWorkerManager, ISingletonDependency
    {
        private readonly IConfiguration _configuration;
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IOptionsMonitor<List<MoHangfireBackgroundWorkerOptions>> _optionsMonitor;
        private readonly ObjectAccessor<HangfireBackgroundWorkerInfos> _hangfireBackgroundWorkerAccessor;

        public ILogger<HangfireBackgroundWorkerManager> Logger { get; set; }

        public HangfireBackgroundWorkerManager(
            IConfiguration configuration,
            IRecurringJobManager recurringJobManager,
            ObjectAccessor<HangfireBackgroundWorkerInfos> objectAccessor,
            IOptionsMonitor<List<MoHangfireBackgroundWorkerOptions>> optionsMonitor)
        {
            _configuration = configuration;
            _optionsMonitor = optionsMonitor;
            _recurringJobManager = recurringJobManager;
            _hangfireBackgroundWorkerAccessor = objectAccessor;
        }

        public void Add(IBackgroundWorker backgroundWorker)
        {
            if (!(backgroundWorker is IHangfireBackgroundWorker hangfireBackgroundWorker))
                Logger.LogWarning($"后台任务【{backgroundWorker.GetType()}】需要实现【{typeof(IHangfireBackgroundWorker)}】接口");
            else
            {
                var hangfireBackgroundWorkerType = hangfireBackgroundWorker.GetType();
                if (hangfireBackgroundWorkerType.IsDefined(typeof(HangfireBackgroundWorkerAttribute), false))
                {
                    var methodInfo = hangfireBackgroundWorkerType.GetMethod("Execute");
                    var hangfireBackgroundWorkerAttribute = hangfireBackgroundWorkerType.GetCustomAttribute<HangfireBackgroundWorkerAttribute>(false);
                    var hangfireBackgroundWorkerOptions = hangfireBackgroundWorkerAttribute as IMoHangfireBackgroundWorkderOptions;
                    hangfireBackgroundWorkerOptions.WorkerType = backgroundWorker.GetType();
                    var validateResult = ValidateBackgroundWorkerOptions(hangfireBackgroundWorkerOptions);
                    if (!validateResult.IsOk())
                        Logger.LogWarning(validateResult.Message);
                    else
                    {
                        var hangfireBackgroundWorkerInfo = new HangfireBackgroundWorkerInfo
                        {
                            WorkerId = hangfireBackgroundWorkerOptions.WorkerId,
                            Cron = hangfireBackgroundWorkerOptions.Cron,
                            TimeZone = hangfireBackgroundWorkerOptions.TimeZone,
                            QueueName = hangfireBackgroundWorkerOptions.QueueName,
                            Method = methodInfo,
                            ExtendedData = hangfireBackgroundWorkerOptions.ExtendData,
                            IsEnabled = hangfireBackgroundWorkerOptions.IsEnabled
                        };

                        var parameterInfos = methodInfo.GetParameters();
                        var arguments = parameterInfos.Select(x => x.ParameterType.IsValueType ? Activator.CreateInstance(x.ParameterType) : null);
                        var hangfireBackgroundJob = new Job(hangfireBackgroundWorkerInfo.Method, arguments);
                        var recurringJobOptions = new RecurringJobOptions { QueueName = hangfireBackgroundWorkerInfo.QueueName, TimeZone = hangfireBackgroundWorkerInfo.TimeZone };
                        _recurringJobManager.AddOrUpdate(hangfireBackgroundWorkerInfo.WorkerId, hangfireBackgroundJob, hangfireBackgroundWorkerInfo.Cron, recurringJobOptions);

                        _hangfireBackgroundWorkerAccessor.Value.RemoveAll(x => x.WorkerId == hangfireBackgroundWorkerInfo.WorkerId);
                        _hangfireBackgroundWorkerAccessor.Value.Add(hangfireBackgroundWorkerInfo);
                    }
                }
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            GlobalConfiguration.Configuration.UseFilter(new HangfireExtendedDataJobFilter(_hangfireBackgroundWorkerAccessor));
            ChangeToken.OnChange(() => _configuration.GetReloadToken(), () =>
            {
                var hangfireBackgroundWorkerOptions = _optionsMonitor.CurrentValue;
                if (hangfireBackgroundWorkerOptions is null)
                    return;
                else
                {
                    hangfireBackgroundWorkerOptions.ForEach(x =>
                    {
                        var validateResult = ValidateBackgroundWorkerOptions(x);
                        if (!validateResult.IsOk())
                            Logger.LogWarning(validateResult.Message);
                        else
                        {
                            if (!typeof(IHangfireBackgroundWorker).IsAssignableFrom(x.WorkerType))
                                Logger.LogWarning($"后台任务【{x.WorkerType}】需要实现【{typeof(IHangfireBackgroundWorker)}】接口");
                            else
                            {
                                var methodInfo = x.WorkerType.GetMethod("Execute");
                                var hangfireBackgroundWorkerInfo = new HangfireBackgroundWorkerInfo
                                {
                                    WorkerId = x.WorkerId,
                                    Cron = x.Cron,
                                    TimeZone = x.TimeZone,
                                    QueueName = x.QueueName,
                                    Method = methodInfo,
                                    ExtendedData = x.ExtendData,
                                    IsEnabled = x.IsEnabled
                                };

                                var parameterInfos = methodInfo.GetParameters();
                                var arguments = parameterInfos.Select(x => x.ParameterType.IsValueType ? Activator.CreateInstance(x.ParameterType) : null);
                                var hangfireBackgroundJob = new Job(hangfireBackgroundWorkerInfo.Method, arguments);
                                var recurringJobOptions = new RecurringJobOptions { QueueName = hangfireBackgroundWorkerInfo.QueueName, TimeZone = hangfireBackgroundWorkerInfo.TimeZone };
                                _recurringJobManager.AddOrUpdate(hangfireBackgroundWorkerInfo.WorkerId, hangfireBackgroundJob, hangfireBackgroundWorkerInfo.Cron, recurringJobOptions);

                                _hangfireBackgroundWorkerAccessor.Value.RemoveAll(x => x.WorkerId == hangfireBackgroundWorkerInfo.WorkerId);
                                _hangfireBackgroundWorkerAccessor.Value.Add(hangfireBackgroundWorkerInfo);
                            }
                        }
                    });
                }
            });

            await Task.FromResult(0);
        }

        public async Task StopAsync(CancellationToken cancellationToken = default)
        {
            await Task.FromResult(0);
        }

        private Result ValidateBackgroundWorkerOptions(IMoHangfireBackgroundWorkderOptions backgroundWorkderOptions)
        {
            if (backgroundWorkderOptions.WorkerType == null)
                return Result.FromError($"后台任务配置：{JsonConvert.SerializeObject(backgroundWorkderOptions)},缺失后台任务类型信息。");
            else if (string.IsNullOrWhiteSpace(backgroundWorkderOptions.WorkerId))
                return Result.FromError($"{backgroundWorkderOptions.WorkerType}对应的 Worker id 不能为空。");
            else if (string.IsNullOrWhiteSpace(backgroundWorkderOptions.Cron))
                return Result.FromError($"Worker id：{backgroundWorkderOptions.WorkerId}，对应的Cron表达式不能为空。");
            else
                return Result.Ok();
        }
    }
}
