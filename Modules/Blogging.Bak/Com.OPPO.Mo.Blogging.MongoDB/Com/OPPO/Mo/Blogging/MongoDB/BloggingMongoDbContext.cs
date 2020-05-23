using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;
using Com.OPPO.Mo.Blogging.Blogs;
using Com.OPPO.Mo.Blogging.Comments;
using Com.OPPO.Mo.Blogging.Posts;
using Com.OPPO.Mo.Blogging.Users;

namespace Com.OPPO.Mo.Blogging.MongoDB
{
    [ConnectionStringName(BloggingDbProperties.ConnectionStringName)]
    public class BloggingMongoDbContext : AbpMongoDbContext, IBloggingMongoDbContext
    {
        public IMongoCollection<BlogUser> Users => Collection<BlogUser>();

        public IMongoCollection<Blog> Blogs => Collection<Blog>();

        public IMongoCollection<Post> Posts => Collection<Post>();

        public IMongoCollection<Tagging.Tag> Tags => Collection<Tagging.Tag>();

        public IMongoCollection<Comment> Comments => Collection<Comment>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureBlogging();
        }
    }
}
