using System;
using Volo.Abp;
using Volo.Abp.MongoDB;
using Com.OPPO.Mo.Blogging.Blogs;
using Com.OPPO.Mo.Blogging.Comments;
using Com.OPPO.Mo.Blogging.Posts;
using Com.OPPO.Mo.Blogging.Users;

namespace Com.OPPO.Mo.Blogging.MongoDB
{
    public static class BloggingMongoDbContextExtensions
    {
        public static void ConfigureBlogging(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new BloggingMongoModelBuilderConfigurationOptions(
                BloggingDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);

            builder.Entity<BlogUser>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Users";
            });

            builder.Entity<Blog>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Blogs";
            });

            builder.Entity<Post>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Posts";
            });

            builder.Entity<Tagging.Tag>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Tags";
            });

            builder.Entity<Comment>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Comments";
            });
        }
    }
}
