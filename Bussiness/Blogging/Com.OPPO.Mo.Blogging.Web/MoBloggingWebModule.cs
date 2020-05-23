using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Com.OPPO.Mo.Blogging.Localization;

namespace Com.OPPO.Mo.Blogging
{
    [DependsOn(
    typeof(MoBloggingHttpApiModule),
    typeof(AbpAspNetCoreMvcUiBootstrapModule),
    typeof(AbpAspNetCoreMvcUiBundlingModule),
    typeof(AbpAutoMapperModule))]
    public class MoBloggingWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(BloggingResource), typeof(MoBloggingWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MoBloggingWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new BloggingMenuContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<MoBloggingWebModule>("Com.OPPO.Mo.Blogging");
            });

            context.Services.AddAutoMapperObjectMapper<MoBloggingWebModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MoBloggingWebAutoMapperProfile>(validate: true);
            });

            Configure<RazorPagesOptions>(options =>
            {
                var urlOptions = context.Services
                    .GetRequiredServiceLazy<IOptions<BloggingUrlOptions>>()
                    .Value.Value;

                var routePrefix = urlOptions.RoutePrefix;

                options.Conventions.AddPageRoute("/Blogs/Posts/Index", routePrefix + "{blogShortName}");
                options.Conventions.AddPageRoute("/Blogs/Posts/Detail", routePrefix + "{blogShortName}/{postUrl}");
                options.Conventions.AddPageRoute("/Blogs/Posts/Edit", routePrefix + "{blogShortName}/posts/{postId}/edit");
                options.Conventions.AddPageRoute("/Blogs/Posts/New", routePrefix + "{blogShortName}/posts/new");
            });
        }
    }
}
