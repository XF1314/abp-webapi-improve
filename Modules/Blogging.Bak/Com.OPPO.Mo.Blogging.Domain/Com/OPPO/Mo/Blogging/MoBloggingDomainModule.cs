using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Modularity;
using Com.OPPO.Mo.Blogging.Blogs;
using Com.OPPO.Mo.Blogging.Comments;
using Com.OPPO.Mo.Blogging.Posts;
using Com.OPPO.Mo.Blogging.Tagging;

namespace Com.OPPO.Mo.Blogging
{
    [DependsOn(
    typeof(MoBloggingDomainSharedModule),
    typeof(AbpDddDomainModule),
    typeof(AbpAutoMapperModule))]
    public class MoBloggingDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MoBloggingDomainModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<BloggingDomainMappingProfile>(validate: true);
            });

            Configure<AbpDistributedEventBusOptions>(options =>
            {
                options.EtoMappings.Add<Blog, BlogEto>(typeof(MoBloggingDomainModule));
                options.EtoMappings.Add<Comment, CommentEto>(typeof(MoBloggingDomainModule));
                options.EtoMappings.Add<Post, PostEto>(typeof(MoBloggingDomainModule));
                options.EtoMappings.Add<Tag, TagEto>(typeof(MoBloggingDomainModule));
            });
        }
    }
}
