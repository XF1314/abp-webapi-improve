using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Com.OPPO.Mo.Blogging.Blogs;
using Com.OPPO.Mo.Blogging.Blogs.Dtos;

namespace Com.OPPO.Mo.Blogging.Web.Pages.Blog
{
    public class IndexModel : AbpPageModel
    {
        private readonly IBlogAppService _blogAppService;

        public IReadOnlyList<BlogDto> Blogs { get; private set; }

        public IndexModel(IBlogAppService blogAppService)
        {
            _blogAppService = blogAppService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var result = await _blogAppService.GetListAsync();

            if (result.Items.Count == 1)
            {
                var blog = result.Items[0];
                return RedirectToPage("./Posts/Index", new { blogShortName = blog.ShortName });
            }

            Blogs = result.Items;

            return Page();
        }
    }
}