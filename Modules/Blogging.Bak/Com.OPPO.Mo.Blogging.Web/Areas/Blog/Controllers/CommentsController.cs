using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Com.OPPO.Mo.Blogging.Comments;
using Com.OPPO.Mo.Blogging.Comments.Dtos;

namespace Com.OPPO.Mo.Blogging.Web.Areas.Blog.Controllers
{
    //TODO: Is that being used?

    [Area("Blog")]
    [Route("Blog/[controller]/[action]")]
    public class CommentsController : BloggingControllerBase
    {
        private readonly ICommentAppService _commentAppService;

        public CommentsController(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;

        }

        [HttpPost]
        public async Task Delete(Guid id)
        {
            await _commentAppService.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Update(Guid id, UpdateCommentDto commentDto)
        {
            await _commentAppService.UpdateAsync(id, commentDto);
        }
    }
}
