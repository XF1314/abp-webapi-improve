using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Com.OPPO.Mo.Blogging.Blogs;
using Com.OPPO.Mo.Blogging.Comments;
using Com.OPPO.Mo.Blogging.Posts;
using Com.OPPO.Mo.Blogging.Tagging;
using Com.OPPO.Mo.Blogging.Users;

namespace Com.OPPO.Mo.Blogging.EntityFrameworkCore
{
    [ConnectionStringName(BloggingDbProperties.ConnectionStringName)]
    public interface IBloggingDbContext : IEfCoreDbContext
    {
        DbSet<BlogUser> Users { get; }

        DbSet<Blog> Blogs { get; set; }

        DbSet<Post> Posts { get; set; }

        DbSet<Comment> Comments { get; set; }

        DbSet<PostTag> PostTags { get; set; }

        DbSet<Tag> Tags { get; set; }
    }
}