using AutoMapper;
using Com.OPPO.Mo.Blogging.Blogs;
using Com.OPPO.Mo.Blogging.Comments;
using Com.OPPO.Mo.Blogging.Posts;
using Com.OPPO.Mo.Blogging.Tagging;

namespace Com.OPPO.Mo.Blogging
{
    public class BloggingDomainMappingProfile : Profile
    {
        public BloggingDomainMappingProfile()
        {
            CreateMap<Blog, BlogEto>();
            CreateMap<Comment, CommentEto>();
            CreateMap<Post, PostEto>();
            CreateMap<Tag, TagEto>();
        }
    }
}