using System.IdentityModel.Tokens.Jwt;
using Volo.Abp.Security.Claims;

namespace Com.OPPO.Mo.IdentityServer
{
    public class MoIdentityServerBuilderOptions
    {
        /// <summary>
        /// Updates <see cref="JwtSecurityTokenHandler.DefaultInboundClaimTypeMap"/> to be compatible with identity server claims.
        /// Default: true.
        /// </summary>
        public bool UpdateJwtSecurityTokenHandlerDefaultInboundClaimTypeMap { get; set; } = true;

        /// <summary>
        /// Updates <see cref="AbpClaimTypes"/> to be compatible with identity server claims.
        /// Default: true.
        /// </summary>
        public bool UpdateAbpClaimTypes { get; set; } = true;

        /// <summary>
        /// Integrate to AspNet Identity.
        /// Default: true.
        /// </summary>
        public bool IntegrateToAspNetIdentity { get; set; } = true;

        /// <summary>
        /// Set false to suppress AddDeveloperSigningCredential() call on the IIdentityServerBuilder.
        /// </summary>
        public bool AddDeveloperSigningCredential { get; set; } = true;
    }
}