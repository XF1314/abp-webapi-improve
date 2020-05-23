using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Com.OPPO.Mo.Blogging.Tagging.Dtos;

namespace Com.OPPO.Mo.Blogging.Tagging
{
    public interface ITagAppService : IApplicationService
    {
        Task<List<TagDto>> GetPopularTags(Guid blogId, GetPopularTagsInput input);

    }
}
