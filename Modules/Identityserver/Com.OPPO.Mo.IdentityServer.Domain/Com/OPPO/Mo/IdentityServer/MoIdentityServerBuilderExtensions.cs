using System;
using System.IdentityModel.Tokens.Jwt;
using IdentityModel;
using IdentityServer4.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Com.OPPO.Mo.IdentityServer.AspNetIdentity;
using Volo.Abp.Security.Claims;
using Com.OPPO.Mo.Identity;

namespace Com.OPPO.Mo.IdentityServer
{
    public static class MoIdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddAbpIdentityServer(
            this IIdentityServerBuilder builder,
            MoIdentityServerBuilderOptions options = null)
        {
            if (options == null)
            {
                options = new MoIdentityServerBuilderOptions();
            }

            //TODO: AspNet Identity integration lines. Can be extracted to a extension method
            if (options.IntegrateToAspNetIdentity)
            {
                builder.AddAspNetIdentity<IdentityUser>();
                builder.AddProfileService<MoProfileService>();
                builder.AddResourceOwnerValidator<MoResourceOwnerPasswordValidator>();
            }

            builder.Services.Replace(ServiceDescriptor.Transient<IClaimsService, MoClaimsService>());

            if (options.UpdateAbpClaimTypes)
            {
                AbpClaimTypes.UserId = JwtClaimTypes.Subject;
                AbpClaimTypes.UserName = JwtClaimTypes.Name;
                AbpClaimTypes.Role = JwtClaimTypes.Role;
                AbpClaimTypes.Email = JwtClaimTypes.Email;
            }

            if (options.UpdateJwtSecurityTokenHandlerDefaultInboundClaimTypeMap)
            {
                JwtSecurityTokenHandler.DefaultInboundClaimTypeMap[AbpClaimTypes.UserId] = AbpClaimTypes.UserId;
                JwtSecurityTokenHandler.DefaultInboundClaimTypeMap[AbpClaimTypes.UserName] = AbpClaimTypes.UserName;
                JwtSecurityTokenHandler.DefaultInboundClaimTypeMap[AbpClaimTypes.Role] = AbpClaimTypes.Role;
                JwtSecurityTokenHandler.DefaultInboundClaimTypeMap[AbpClaimTypes.Email] = AbpClaimTypes.Email;
            }

            return builder;
        }
    }
}