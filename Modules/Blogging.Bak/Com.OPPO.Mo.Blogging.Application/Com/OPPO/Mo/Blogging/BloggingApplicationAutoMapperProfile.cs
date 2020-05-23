using AutoMapper;
using Volo.Abp.AutoMapper;
using Com.OPPO.Mo.Blogging.Blogs;
using Com.OPPO.Mo.Blogging.Blogs.Dtos;
using Com.OPPO.Mo.Blogging.Comments;
using Com.OPPO.Mo.Blogging.Comments.Dtos;
using Com.OPPO.Mo.Blogging.Posts;
using Com.OPPO.Mo.Blogging.Tagging;
using Com.OPPO.Mo.Blogging.Tagging.Dtos;
using Com.OPPO.Mo.Blogging.Users;

namespace Com.OPPO.Mo.Blogging
{
    public class BloggingApplicationAutoMapperProfile : Profile
    {
        public BloggingApplicationAutoMapperProfile()
        {
            CreateMap<Blog, BlogDto>();
            CreateMap<BlogUser, BlogUserDto>();
            CreateMap<Post, PostWithDetailsDto>().Ignore(x=>x.Writer).Ignore(x=>x.CommentCount).Ignore(x=>x.Tags);
            CreateMap<Comment, CommentWithDetailsDto>().Ignore(x => x.Writer);
            CreateMap<Tag, TagDto>();
        }
    }
}
