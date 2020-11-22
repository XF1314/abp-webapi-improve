using Castle.Core.Logging;
using Com.OPPO.Mo.MasterData.InboxMail;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Schedule
{
    public class DemoRecurringJobHostedService : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly ILogger<DemoRecurringJobHostedService> _logger;

        private readonly IInboxMailAppService _inboxMailAppService;

        public DemoRecurringJobHostedService(
             IConfiguration configuration,
        IInboxMailAppService inboxMailAppService,
            IBackgroundJobClient backgroundJobClient,
            IRecurringJobManager recurringJobManager,
            ILogger<DemoRecurringJobHostedService> logger)
        {
            _configuration = configuration;
            _inboxMailAppService = inboxMailAppService;
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
            _logger = logger;
        }


        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("*********************** TestRecurringJob ************************************");

            try
            {
                RecurringJob.AddOrUpdate("seconds", () => Console.WriteLine("Hello,seconds!"), "*/15 * * * * *");
                BackgroundJob.Schedule(() => Test(), TimeSpan.FromMinutes(1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Test()
        {
            var ss = _configuration["TestKey"];
            Console.WriteLine(ss);
        }
    }
}
