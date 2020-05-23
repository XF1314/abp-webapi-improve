using Com.OPPO.Mo.Users.MongoDB;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using Com.OPPO.Mo.Blogging.Blogs;
using Com.OPPO.Mo.Blogging.Comments;
using Com.OPPO.Mo.Blogging.Posts;
using Com.OPPO.Mo.Blogging.Tagging;
using Com.OPPO.Mo.Blogging.Users;

namespace Com.OPPO.Mo.Blogging.MongoDB
{
    [DependsOn(
    typeof(MoBloggingDomainModule),
    typeof(AbpMongoDbModule),
    typeof(MoUsersMongoDbModule)    )]
    public class MoBloggingMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<BloggingMongoDbContext>(options =>
            {
                options.AddRepository<Blog, MongoBlogRepository>();
                options.AddRepository<BlogUser, MongoBlogUserRepository>();
                options.AddRepository<Post, MongoPostRepository>();
                options.AddRepository<Tag, MongoTagRepository>();
                options.AddRepository<Comment, MongoCommentRepository>();
            });
        }
    }
}
