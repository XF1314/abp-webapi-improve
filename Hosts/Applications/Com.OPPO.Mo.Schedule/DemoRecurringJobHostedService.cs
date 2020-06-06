using Castle.Core.Logging;
using Com.OPPO.Mo.Inmail.InboxMail;
using Hangfire;
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
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly ILogger<DemoRecurringJobHostedService> _logger;

        private readonly IInboxMailAppService _inboxMailAppService;

        public DemoRecurringJobHostedService(
            IInboxMailAppService inboxMailAppService,
            IBackgroundJobClient backgroundJobClient,
            IRecurringJobManager recurringJobManager,
            ILogger<DemoRecurringJobHostedService> logger)
        {
            _inboxMailAppService = inboxMailAppService;
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
            _logger = logger;
        }


        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("*** TestInboxMailService ************************************");

            try
            {
                RecurringJob.AddOrUpdate("seconds", () => Console.WriteLine("Hello,seconds!"), "*/15 * * * * *");
                BackgroundJob.Schedule(() =>
                    //var output = _inboxMailAppService.GetMailCodeBySenderName("郑龙").GetAwaiter().GetResult();
                    //Console.WriteLine("Total inboxMail count: " + output.Data.Count);
                    Console.WriteLine("Hello,schedule!")
                , TimeSpan.FromMinutes(1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
