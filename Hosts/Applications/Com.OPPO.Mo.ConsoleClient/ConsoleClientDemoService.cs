using Com.OPPO.Mo.Identity;
using Com.OPPO.Mo.Inmail.InboxMail;
using Com.OPPO.Mo.TenantManagement;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.IdentityModel;

namespace Com.OPPO.Mo.ConsoleClient
{
    public class ConsoleClientDemoService : ITransientDependency
    {
        private readonly IIdentityModelAuthenticationService _identityModelAuthenticationService;
        private readonly IIdentityUserAppService _identityUserAppService;
        private readonly ITenantAppService _tenantAppService;
        private readonly IInboxMailAppService _inboxMailAppService;
        private readonly AbpRemoteServiceOptions _remoteServiceOptions;

        public ConsoleClientDemoService(
            ITenantAppService tenantAppService,
            IInboxMailAppService inboxMailAppService,
            IIdentityUserAppService identityUserAppService,
            IOptions<AbpRemoteServiceOptions> remoteServiceOptions,
            IIdentityModelAuthenticationService identityModelAuthenticationService)
        {
            _tenantAppService = tenantAppService;
            _inboxMailAppService = inboxMailAppService;
            _identityUserAppService = identityUserAppService;
            _remoteServiceOptions = remoteServiceOptions.Value;
            _identityModelAuthenticationService = identityModelAuthenticationService;
        }

        public async Task RunAsync()
        {
            await TestWithHttpClient();
            await TestIdentityService();
            await TestTenantManagementService();
            await TestInboxMailService();
        }

        /// <summary>
        /// Shows how to manually create an HttpClient and authenticate using the
        /// IIdentityModelAuthenticationService service.
        /// </summary>
        private async Task TestWithHttpClient()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestWithHttpClient ************************************");

            try
            {
                using (var httpClient = new HttpClient())
                {
                    await _identityModelAuthenticationService.TryAuthenticateAsync(httpClient);

                    var url = $"{_remoteServiceOptions.RemoteServices.Default.BaseUrl.EnsureEndsWith('/')}api/internal-gateway/test";
                    var response = await httpClient.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        Console.WriteLine(response.StatusCode);
                    else
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseContent);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Shows how to use application service interfaces (IIdentityUserAppService in this sample)
        /// to call a remote service which is possible by the dynamic http client proxy system.
        /// No need to use IIdentityModelAuthenticationService since the dynamic http client proxy
        /// system internally uses it. You just inject a service (IIdentityUserAppService)
        /// and call a method (GetListAsync) like a local method.
        /// </summary>
        private async Task TestIdentityService()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestIdentityService ************************************");

            try
            {
                var output = await _identityUserAppService.GetListAsync(new GetIdentityUsersInput());

                Console.WriteLine("Total user count: " + output.TotalCount);
                foreach (var user in output.Items)
                {
                    Console.WriteLine($"- UserName={user.UserName}, Email={user.Email}, Name={user.Name}, Surname={user.Surname}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Shows how to use application service interfaces (ITenantAppService in this sample)
        /// to call a remote service which is possible by the dynamic http client proxy system.
        /// No need to use IIdentityModelAuthenticationService since the dynamic http client proxy
        /// system internally uses it. You just inject a service (ITenantAppService)
        /// and call a method (GetListAsync) like a local method.
        /// </summary>
        private async Task TestTenantManagementService()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestTenantManagementService ************************************");

            try
            {
                var output = await _tenantAppService.GetListAsync(new GetTenantsInput());

                Console.WriteLine("Total tenant count: " + output.TotalCount);

                foreach (var tenant in output.Items)
                {
                    Console.WriteLine($"- Id={tenant.Id}, Name={tenant.Name}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Shows how to use application service interfaces (InboxMailAppService in this sample)
        /// to call a remote service which is possible by the dynamic http client proxy system.
        /// No need to use IIdentityModelAuthenticationService since the dynamic http client proxy
        /// system internally uses it. You just inject a service (InboxMailAppService)
        /// and call a method (GetMailCodeBySenderName) like a local method.
        /// </summary>
        private async Task TestInboxMailService()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestInboxMailService ************************************");

            try
            {
                var output = await _inboxMailAppService.GetMailCodeBySenderName("郑龙");
                Console.WriteLine("Total inboxMail count: " + output.Data.Count);
              
                Console.WriteLine(output.Data.JoinAsString("/r/n"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
