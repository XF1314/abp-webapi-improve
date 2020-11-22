using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.MasterDataService.Filters
{
    public class SwaggerIgnoreFilter : IDocumentFilter
    {
        private ImmutableList<string> ignoreControllerNames { get; } = new List<string>
        {
            "AbpApiDefinition",
            "AbpApplicationConfiguration",
            "AbpApplicationConfigurationScript",
            "AbpLanguages",
            "AbpServiceProxyScript",
            "AbpTenant",
            "Features",
            "FileConfiguration",
            "OutputCache",
            "Permissions"
        }.ToImmutableList();

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext filterContext)
        {
            var ignoreApis = filterContext.ApiDescriptions
                .Where(x => ignoreControllerNames.Contains(x.ActionDescriptor.AsControllerActionDescriptor().ControllerName))
                .Select(x => $"/{ x.RelativePath}")
                .ToList();

            ignoreApis.ForEach(y => swaggerDoc.Paths.Remove(y));
        }
    }
}
