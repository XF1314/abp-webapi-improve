using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Com.OPPO.Mo.Blogging.Tagging;
using Com.OPPO.Mo.Blogging.Tagging.Dtos;

namespace Com.OPPO.Mo.Blogging
{
    [RemoteService(Name = BloggingRemoteServiceConsts.RemoteServiceName)]
    [Area("blogging")]
    [Route("api/blogging/tags")]
    public class TagsController : AbpController, ITagAppService
    {
        private readonly ITagAppService _tagAppService;

        public TagsController(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }

        [HttpGet]
        [Route("popular/{blogId}")]
        public Task<List<TagDto>> GetPopularTags(Guid blogId, GetPopularTagsInput input)
        {
            return _tagAppService.GetPopularTags(blogId, input);
        }
    }
}
