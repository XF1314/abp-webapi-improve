using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Com.OPPO.Mo.Blogging.Blogs;
using Com.OPPO.Mo.Blogging.Blogs.Dtos;
using Com.OPPO.Mo.Blogging.Posts;

namespace Com.OPPO.Mo.Blogging.Pages.Blog.Posts
{
    public class NewModel : BloggingPageModel
    {
        private readonly IPostAppService _postAppService;
        private readonly IBlogAppService _blogAppService;
        private readonly IAuthorizationService _authorization;
        private readonly BloggingUrlOptions _blogOptions;

        [BindProperty(SupportsGet = true)]
        public string BlogShortName { get; set; }

        [BindProperty]
        public CreatePostViewModel Post { get; set; }

        public BlogDto Blog { get; set; }

        public NewModel(IPostAppService postAppService, IBlogAppService blogAppService, IAuthorizationService authorization, IOptions<BloggingUrlOptions> blogOptions)
        {
            _postAppService = postAppService;
            _blogAppService = blogAppService;
            _authorization = authorization;
            _blogOptions = blogOptions.Value;
        }

        public async Task<ActionResult> OnGetAsync()
        {
            if (!await _authorization.IsGrantedAsync(BloggingPermissions.Posts.Create))
            {
                return Redirect("/");
            }

            Blog = await _blogAppService.GetByShortNameAsync(BlogShortName);
            Post = new CreatePostViewModel
            {
                BlogId = Blog.Id
            };

            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            var blog = await _blogAppService.GetAsync(Post.BlogId);

            if (string.IsNullOrEmpty(Post.Description))
            {
                Post.Description = Post.Content.Truncate(PostConsts.MaxSeoFriendlyDescriptionLength);
            }

            var postWithDetailsDto = await _postAppService.CreateAsync(ObjectMapper.Map<CreatePostViewModel, CreatePostDto>(Post));

            //TODO: Try Url.Page(...)
            var urlPrefix = _blogOptions.RoutePrefix;
            return Redirect(Url.Content($"~{urlPrefix}{WebUtility.UrlEncode(blog.ShortName)}/{WebUtility.UrlEncode(postWithDetailsDto.Url)}"));
        }

        public class CreatePostViewModel
        {
            [Required]
            [HiddenInput]
            public Guid BlogId { get; set; }

            [Required]
            [StringLength(PostConsts.MaxTitleLength)]
            public string Title { get; set; }

            [Required]
            [HiddenInput]
            public string CoverImage { get; set; }

            [Required]
            [StringLength(PostConsts.MaxUrlLength)]
            public string Url { get; set; }

            [HiddenInput]
            [StringLength(PostConsts.MaxContentLength)]
            public string Content { get; set; }

            public string Tags { get; set; }

            [StringLength(PostConsts.MaxDescriptionLength)]
            public string Description { get; set; }

        }
    }
}