﻿using AutoMapper;
using Volo.Abp.AutoMapper;
using Com.OPPO.Mo.Blogging.Blogs;
using Com.OPPO.Mo.Blogging.Blogs.Dtos;
using Com.OPPO.Mo.Blogging.Pages.Admin.Blogs;
using Com.OPPO.Mo.Blogging.Pages.Blog.Posts;
using Com.OPPO.Mo.Blogging.Posts;
using EditModel = Com.OPPO.Mo.Blogging.Pages.Admin.Blogs.EditModel;
using IndexModel = Com.OPPO.Mo.Blogging.Pages.Blog.IndexModel;

namespace Com.OPPO.Mo.Blogging
{
    public class MoBloggingWebAutoMapperProfile : Profile
    {
        public MoBloggingWebAutoMapperProfile()
        {
            CreateMap<PostWithDetailsDto, EditPostViewModel>().Ignore(x=>x.Tags);
            CreateMap<NewModel.CreatePostViewModel, CreatePostDto>();
            CreateMap<CreateModel.BlogCreateModalView, CreateBlogDto>();
            CreateMap<BlogDto, EditModel.BlogEditViewModel>();
        }
    }
}
