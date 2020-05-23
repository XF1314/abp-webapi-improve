using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Com.OPPO.Mo.Blogging.Blogs;
using Com.OPPO.Mo.Blogging.Blogs.Dtos;
using Com.OPPO.Mo.Blogging.Posts;
using Com.OPPO.Mo.Blogging.Tagging;
using Com.OPPO.Mo.Blogging.Tagging.Dtos;

namespace Com.OPPO.Mo.Blogging.Pages.Blog.Posts
{
    public class IndexModel : BloggingPageModel
    {
        private readonly IPostAppService _postAppService;
        private readonly IBlogAppService _blogAppService;
        private readonly ITagAppService _tagAppService;

        [BindProperty(SupportsGet = true)]
        public string BlogShortName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TagName { get; set; }

        public BlogDto Blog { get; set; }

        public IReadOnlyList<PostWithDetailsDto> Posts { get; set; }

        public IReadOnlyList<TagDto> PopularTags { get; set; }

        public IndexModel(IPostAppService postAppService, IBlogAppService blogAppService, ITagAppService tagAppService)
        {
            _postAppService = postAppService;
            _blogAppService = blogAppService;
            _tagAppService = tagAppService;
        }

        public async Task OnGetAsync()
        {
            Blog = await _blogAppService.GetByShortNameAsync(BlogShortName);
            Posts = (await _postAppService.GetListByBlogIdAndTagName(Blog.Id, TagName)).Items;
            PopularTags = (await _tagAppService.GetPopularTags(Blog.Id, new GetPopularTagsInput {ResultCount = 10, MinimumPostCount = 2}));
        }
    }
}