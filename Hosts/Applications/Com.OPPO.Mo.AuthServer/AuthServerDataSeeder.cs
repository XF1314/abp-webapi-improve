using Com.Ctrip.Framework.Apollo;
using Com.OPPO.Mo.Account.Settings;
using Com.OPPO.Mo.Identity;
using Com.OPPO.Mo.IdentityServer.ApiResources;
using Com.OPPO.Mo.IdentityServer.Clients;
using Com.OPPO.Mo.IdentityServer.IdentityResources;
using Com.OPPO.Mo.PermissionManagement;
using Com.OPPO.Mo.SettingManagement;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Uow;
using MoApiResources = Com.OPPO.Mo.IdentityServer.ApiResources;
using MoClients = Com.OPPO.Mo.IdentityServer.Clients;

namespace Com.OPPO.Mo.AuthServer
{
    public class AuthServerDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IConfiguration _configuration;
        private readonly IApiResourceRepository _apiResourceRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IIdentityResourceDataSeeder _identityResourceDataSeeder;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IPermissionDataSeeder _permissionDataSeeder;
        private readonly ISettingRepository _settingRepository;

        public AuthServerDataSeeder(
             IConfiguration configuration,
            IClientRepository clientRepository,
            IApiResourceRepository apiResourceRepository,
            IIdentityResourceDataSeeder identityResourceDataSeeder,
            IGuidGenerator guidGenerator,
            ISettingRepository settingRepository,
            IPermissionDataSeeder permissionDataSeeder)
        {
            _configuration = configuration;
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
                    new Setting(_guidGenerator.Create(), AccountSettingNames.EnableLocalLogin, "true"),
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
            await CreateApiResourceAsync("MoBpmService", commonApiUserClaims);
            await CreateApiResourceAsync("MoInternalGateway", commonApiUserClaims);
            await CreateApiResourceAsync("MoMasterDataService", commonApiUserClaims);
            await CreateApiResourceAsync("MoThirdpartyService", commonApiUserClaims);
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
                    apiResource.AddUserClaim(claim);
            }

            return await _apiResourceRepository.UpdateAsync(apiResource);
        }

        private async Task CreateClientsAsync()
        {
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
                name: "mo-console",
                scopes: new[] { "MoMasterDataService", "MoInternalGateway" },
                grantTypes: new[] { IdentityModel.OidcConstants.GrantTypes.ClientCredentials },// "password"
                secret: commonSecret,
                permissions: new[] { IdentityPermissions.Users.Default, "MoMasterData.Inmail.InboxMails" }
            );
            await CreateClientAsync(
                name: "mo-schedule-service",
                scopes: new[] { "MoMasterDataService", "MoInternalGateway" },
                grantTypes: new[] { IdentityModel.OidcConstants.GrantTypes.ClientCredentials },
                secret: commonSecret,
                permissions: new[] { IdentityPermissions.Users.Default, "MoMasterData.Inmail.InboxMails" }
            );
            await CreateClientAsync(
                name: "mo-backend-admin",
                scopes: commonScopes.Union(new[] { "MoInternalGateway", "MoThirdpartyService", "MoBpmService", "offline_access" }),
                grantTypes: new[] { "hybrid"/*IdentityModel.OidcConstants.GrantTypes.AuthorizationCode*/ },//hybrid
                secret: commonSecret,
                requireConsent: false,
                requirePkce: false,
                permissions: new[] { IdentityPermissions.UserLookup.Default, IdentityPermissions.Users.Default },
                allowedCorsOrigins: new[] { "http://localhost:51462", "http://172.16.44.115:6108", "http://172.16.46.115:6108" },
                redirectUris: new List<string> {
                    "http://localhost:51462/signin-oidc",
                    "http://localhost:51462/swagger/oauth2-redirect.html",
                    "http://172.16.44.115:6108/signin-oidc",
                    "http://172.16.44.115:6108/swagger/oauth2-redirect.html",
                    "http://172.16.46.115:6108/signin-oidc",
                    "http://172.16.46.115:6108/swagger/oauth2-redirect.html"},
                postLogoutRedirectUri: "http://localhost:51462/signout-callback-oidc"
            );
            await CreateClientAsync(
                name: "mo-bpm-service",
                scopes: new[] { "MoBpmService" },
                grantTypes: new[] { IdentityModel.OidcConstants.GrantTypes.ClientCredentials },
                secret: commonSecret,
                allowedCorsOrigins: new[] { "http://localhost:54579", "http://172.16.44.115:6104", "http://172.16.46.115:6104","http://172.16.40.194:6104", "http://172.16.40.195:6104" },
                redirectUris: new List<string> {
                    "http://172.16.44.115:6104/signin-oidc",
                    "http://172.16.44.115:6104/swagger/oauth2-redirect.html",
                    "http://172.16.46.115:6104/signin-oidc",
                    "http://172.16.46.115:6104/swagger/oauth2-redirect.html",
                    "http://localhost:54579/signin-oidc",
                    "http://localhost:54579/swagger/oauth2-redirect.html" ,
                    "http://172.16.40.194:6104/signin-oidc",
                    "http://172.16.40.194:6104/swagger/oauth2-redirect.html",
                    "http://172.16.40.195:6104/signin-oidc",
                    "http://172.16.40.195:6104/swagger/oauth2-redirect.html",},
                permissions: new[] { IdentityPermissions.UserLookup.Default, IdentityPermissions.Users.Default }
                );
            await CreateClientAsync(
                name: "mo-masterdata-service",
                scopes: new[] { "MoMasterDataService" },
                grantTypes: new[] { IdentityModel.OidcConstants.GrantTypes.ClientCredentials },//IdentityModel.OidcConstants.GrantTypes.AuthorizationCode
                secret: commonSecret,
                allowedCorsOrigins: new List<string> { "http://localhost:54541", "http://172.16.44.115:6102", "http://172.16.46.115:6102" },
                redirectUris: new List<string> {
                    "http://172.16.44.115:6102/swagger/oauth2-redirect.html",
                    "http://172.16.44.115:6102/signin-oidc",
                    "http://172.16.46.115:6102/swagger/oauth2-redirect.html",
                    "http://172.16.46.115:6102/signin-oidc",
                    "http://localhost:54541/swagger/oauth2-redirect.html",
                    "http://localhost:54541/signin-oidc" },
                permissions: new[] { IdentityPermissions.UserLookup.Default, IdentityPermissions.Users.Default, "MoMasterData.Inmail.InboxMails" }
            );
            await CreateClientAsync(
                name: "mo-thirdparty-service",
                scopes: new[] { "MoThirdpartyService" },
                grantTypes: new[] { IdentityModel.OidcConstants.GrantTypes.ClientCredentials },
                secret: commonSecret,
                allowedCorsOrigins: new List<string> { "http://localhost:54668", "http://172.16.44.115:6106", "http://172.16.46.115:6106", "http://172.16.40.194:6106", "http://172.16.40.195:6106" },
                redirectUris: new List<string> {
                    "http://172.16.44.115:6106/swagger/oauth2-redirect.html",
                    "http://172.16.44.115:6106/signin-oidc",
                    "http://172.16.46.115:6106/swagger/oauth2-redirect.html",
                    "http://172.16.46.115:6106/signin-oidc",
                    "http://localhost:54668/swagger/oauth2-redirect.html",
                    "http://localhost:54668/signin-oidc",
                    "http://172.16.40.194:6106/signin-oidc",
                    "http://172.16.40.194:6106/swagger/oauth2-redirect.html",
                    "http://172.16.40.195:6106/signin-oidc",
                    "http://172.16.40.195:6106/swagger/oauth2-redirect.html",                },
                permissions: new[] { IdentityPermissions.UserLookup.Default, IdentityPermissions.Users.Default }
            );
            await CreateClientAsync(
                name: "mo-gateway-internal",
                scopes: new[] { "MoInternalGateway", "MoMasterDataService", "MoThirdpartyService", "MoBpmService" },
                grantTypes: new[] { IdentityModel.OidcConstants.GrantTypes.ClientCredentials },//implicit
                secret: commonSecret,
                allowedCorsOrigins: new List<string> { "http://localhost:54415", "http://172.16.44.115:6110", "http://172.16.46.115:6110", "http://172.16.40.193:6110" , "http://172.16.40.195:6110" },
                redirectUris: new List<string> {
                    "http://localhost:54415/swagger/oauth2-redirect.html",
                    "http://172.16.44.115:6110/swagger/oauth2-redirect.html",
                    "http://172.16.46.115:6110/swagger/oauth2-redirect.html",
                    "http://172.16.40.193:6110/swagger/oauth2-redirect.html",
                    "http://172.16.40.195:6110/swagger/oauth2-redirect.html"
                },
                permissions: new[] { IdentityPermissions.UserLookup.Default, IdentityPermissions.Users.Default }
            );
            await CreateClientAsync(
                name: "oppo-upm",
                scopes: new[] { "MoBpmService" },
                grantTypes: new[] { IdentityModel.OidcConstants.GrantTypes.ClientCredentials },//implicit
                secret: commonSecret,
                allowedCorsOrigins: new List<string> { "http://localhost:54415", "http://172.16.44.115:6110", "http://172.16.46.115:6110" },
                redirectUris: new List<string> {
                    "http://localhost:54415/swagger/oauth2-redirect.html",
                    "http://172.16.44.115:6110/swagger/oauth2-redirect.html",
                    "http://172.16.46.115:6110/swagger/oauth2-redirect.html"
                },
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
                    new MoClients.Client(_guidGenerator.Create(), name)
                    {
                        ClientName = name,
                        Description = name,
                        RequireConsent = requireConsent,
                        RequirePkce = requirePkce,
                        AllowAccessTokensViaBrowser = true,
                        AlwaysIncludeUserClaimsInIdToken = true,
                        AllowOfflineAccess = true,
                        IdentityTokenLifetime = 300,//5 minutes
                        AuthorizationCodeLifetime = 300,//5 minutes
                        AccessTokenLifetime = 7200, //2 hours
                        AbsoluteRefreshTokenLifetime = 604800 //7 days
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
