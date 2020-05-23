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
    public interface IBloggingMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<BlogUser> Users { get; }

        IMongoCollection<Blog> Blogs { get; }

        IMongoCollection<Post> Posts { get; }

        IMongoCollection<Tagging.Tag> Tags { get; }

        IMongoCollection<Comment> Comments { get; }

    }
}