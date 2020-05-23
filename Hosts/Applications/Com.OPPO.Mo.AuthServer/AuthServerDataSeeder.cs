using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Uow;
using Volo.Abp.Authorization.Permissions;
using static IdentityModel.OidcConstants;
using IdentityServer4.Models;
using MoApiResources = Com.OPPO.Mo.IdentityServer.ApiResources;
using MoClients = Com.OPPO.Mo.IdentityServer.Clients;
using Com.OPPO.Mo.PermissionManagement;
using Com.OPPO.Mo.Identity;
using Com.OPPO.Mo.Account.Settings;
using Com.OPPO.Mo.IdentityServer.ApiResources;
using Com.OPPO.Mo.IdentityServer.Clients;
using Com.OPPO.Mo.IdentityServer.IdentityResources;
using Com.OPPO.Mo.SettingManagement;
using Com.OPPO.Mo.TenantManagement;
using Microsoft.AspNetCore.Identity;

namespace Com.OPPO.Mo.AuthServer
{
    public class AuthServerDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IApiResourceRepository _apiResourceRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IIdentityResourceDataSeeder _identityResourceDataSeeder;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IPermissionDataSeeder _permissionDataSeeder;
        private readonly ISettingRepository _settingRepository;

        public AuthServerDataSeeder(
            IClientRepository clientRepository,
            IApiResourceRepository apiResourceRepository,
            IIdentityResourceDataSeeder identityResourceDataSeeder,
            IGuidGenerator guidGenerator,
            ISettingRepository settingRepository,
            IPermissionDataSeeder permissionDataSeeder)
        {
            _clientRepository = clientRepository;
            _apiResourceRepository = apiResourceRepository;
            _identityResourceDataSeeder = identityResourceDataSeeder;
            _guidGenerator = guidGenerator;
            _permissionDataSeeder = permissionDataSeeder;
            _settingRepository = settingRepository;
        }

        [UnitOfWork]
        public virtual async Task SeedAsync(DataSeedContext context)
        {
            await _identityResourceDataSeeder.CreateStandardResourcesAsync();
            await CreateApiResourcesAsync();
            await CreateClientsAsync();
            await CreateSettingsAsync();
        }

        private async Task CreateSettingsAsync()
        {
            var setting = await _settingRepository.FindAsync(AccountSettingNames.EnableLocalLogin, null, null);
            if (setting == null)
            {
                setting = await _settingRepository.InsertAsync(
                    new Setting(
                        _guidGenerator.Create(),
                        AccountSettingNames.EnableLocalLogin,
                        "true"
                    ),
                    autoSave: true
                );
            }
        }

        private async Task CreateApiResourcesAsync()
        {
            var commonApiUserClaims = new[]
            {
                "email",
                "email_verified",
                "name",
                "phone_number",
                "phone_number_verified",
                "role"
            };

            await CreateApiResourceAsync("MoExternalService", commonApiUserClaims);
            await CreateApiResourceAsync("MoInmailService", commonApiUserClaims);
            await CreateApiResourceAsync("MoBloggingService", commonApiUserClaims);
            await CreateApiResourceAsync("MoWorkflowService", commonApiUserClaims);
            await CreateApiResourceAsync("MoPublicGateway", commonApiUserClaims);
            await CreateApiResourceAsync("MoInternalGateway", commonApiUserClaims);
            await CreateApiResourceAsync("MoIdentityService", commonApiUserClaims);
        }

        private async Task<MoApiResources.ApiResource> CreateApiResourceAsync(string name, IEnumerable<string> claims)
        {
            var apiResource = await _apiResourceRepository.FindByNameAsync(name);
            if (apiResource == null)
            {
                apiResource = await _apiResourceRepository.InsertAsync(
                    new MoApiResources.ApiResource(
                        _guidGenerator.Create(),
                        name,
                        name + " API"
                    ),
                    autoSave: true
                );
            }

            foreach (var claim in claims)
            {
                if (apiResource.FindClaim(claim) == null)
                {
                    apiResource.AddUserClaim(claim);
                }
            }

            return await _apiResourceRepository.UpdateAsync(apiResource);
        }

        private async Task CreateClientsAsync()
        {
            //const string commonSecret = "E5Xd4yMqjP5kjWFKrYgySBju6JVfCzMyFp7n2QmMrME=";
            var commonSecret = "1q2w3E*".Sha256();
            var commonScopes = new[]
            {
                "email",
                "openid",
                "profile",
                "role",
                "phone",
                "address"
            };

            await CreateClientAsync(
                name: "mo-console-client",
                scopes: new[] { "MoExternalService", "MoBloggingService", "MoInmailService", "MoWorkflowService", "MoPublicGateway", "MoInternalGateway", "MoIdentityService" },
                grantTypes: new[] { "client_credentials", "password" },
                secret: commonSecret,
                permissions: new[] { IdentityPermissions.Users.Default, TenantManagementPermissions.Tenants.Default,"MoInmail.InboxMails"}
            );

            await CreateClientAsync(
                name: "mo-backend-admin-client",
                scopes: commonScopes.Union(new[] { "MoInternalGateway", "MoIdentityService", "MoBloggingService", "MoExternalService", "MoInmailService", "MoWorkflowService", "offline_access" }),
                grantTypes: new[] { "hybrid" },//implict
                secret: commonSecret,
                //requireConsent: true,
                //requirePkce: true,
                permissions: new[] { IdentityPermissions.Users.Default},
                allowedCorsOrigins:new[] { "http://localhost:51462" },
                redirectUris: new List<string> { "http://localhost:51462/signin-oidc", "http://localhost:51462/swagger/oauth2-redirect.html" },
                postLogoutRedirectUri: "http://localhost:51462/signout-callback-oidc"
            );
            await CreateClientAsync(
                 name: "mo-identity-service-client",
                scopes: new[] { "MoInternalGateway", "MoIdentityService", "offline_access" },
                grantTypes: new[] { "authorization_code"},
                secret: commonSecret,
                requireConsent: true,
                requirePkce: true,
                allowedCorsOrigins: new List<string> { "http://localhost:60549" },
                redirectUris: new List<string> { "http://localhost:60549/swagger/oauth2-redirect.html", "http://localhost:60549/signin-oidc" },
                permissions: new[] { IdentityPermissions.UserLookup.Default, IdentityPermissions.Users.Default }
            );
            await CreateClientAsync(
                 name: "mo-inmail-service-client",
                scopes: new[] { "MoInmailService", "offline_access" },
                grantTypes: new[] { "authorization_code" },
                secret: commonSecret,
                requireConsent: true,
                requirePkce: true,
                allowedCorsOrigins: new List<string> { "http://localhost:54541" },
                redirectUris: new List<string> { "http://localhost:54541/swagger/oauth2-redirect.html", "http://localhost:54541/signin-oidc" },
                permissions: new[] { IdentityPermissions.UserLookup.Default, IdentityPermissions.Users.Default }
            );
            await CreateClientAsync(
                 name: "mo-gateway-internal",
                scopes: new[] { "MoInternalGateway","MoBloggingService", "MoExternalService", "MoInmailService", "MoWorkflowService", "MoIdentityService", "offline_access" },
                grantTypes: new[] { "authorization_code" },//implicit
                secret: commonSecret,
                requireConsent: true,
                requirePkce: true,
                allowedCorsOrigins: new List<string> { "http://localhost:54415" },
                redirectUris: new List<string> { "http://localhost:54415/swagger/oauth2-redirect.html" },
                permissions: new[] { IdentityPermissions.UserLookup.Default, IdentityPermissions.Users.Default }
            );
        }

        private async Task<MoClients.Client> CreateClientAsync(
            string name,
            IEnumerable<string> scopes,
            IEnumerable<string> grantTypes,
            string secret,
            bool requireConsent = false,
            bool requirePkce = false,
            IList<string> redirectUris = null,
            string postLogoutRedirectUri = null,
            IList<string> allowedCorsOrigins = null,
            IEnumerable<string> permissions = null)
        {
            var client = await _clientRepository.FindByCliendIdAsync(name);
            if (client == null)
            {
                client = await _clientRepository.InsertAsync(
                    new MoClients.Client(
                        _guidGenerator.Create(),
                        name
                    )
                    {
                        ClientName = name,
                        Description = name,
                        RequireConsent = requireConsent,
                        RequirePkce = requirePkce,
                        AllowAccessTokensViaBrowser = true,
                        AlwaysIncludeUserClaimsInIdToken = true,
                        AllowOfflineAccess = true,
                        IdentityTokenLifetime = 300,
                        AuthorizationCodeLifetime = 300,
                        AccessTokenLifetime = 31536000, //365 days
                        AbsoluteRefreshTokenLifetime = 31536000 //365 days
                    },
                    autoSave: true
                );
            }
            if (client.FindSecret(secret) == null)
            {
                client.AddSecret(secret);
            }

            if (scopes != null)
                foreach (var scope in scopes)
                {
                    if (client.FindScope(scope) == null)
                        client.AddScope(scope);
                }

            if (grantTypes != null)
                foreach (var grantType in grantTypes)
                {
                    if (client.FindGrantType(grantType) == null)
                        client.AddGrantType(grantType);
                }

            if (allowedCorsOrigins != null)
                foreach (var allowedCoresOrigin in allowedCorsOrigins)
                {
                    if (client.FindCorsOrigin(allowedCoresOrigin) == null)
                        client.AddCorsOrigin(allowedCoresOrigin);
                }

            if (redirectUris != null)
                foreach (var redirectUri in redirectUris)
                    if (client.FindRedirectUri(redirectUri) == null)
                        client.AddRedirectUri(redirectUri);


            if (postLogoutRedirectUri != null)
            {
                if (client.FindPostLogoutRedirectUri(postLogoutRedirectUri) == null)
                    client.AddPostLogoutRedirectUri(postLogoutRedirectUri);
            }

            if (permissions != null)
            {
                await _permissionDataSeeder.SeedAsync(
                    ClientPermissionValueProvider.ProviderName,
                    name,
                    permissions
                );
            }

            return await _clientRepository.UpdateAsync(client);
        }
    }
}
