﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.OPPO.Mo.Blogging.Tagging.Dtos;

namespace Com.OPPO.Mo.Blogging.Tagging
{
    public class TagAppService : BloggingAppServiceBase, ITagAppService
    {
        private readonly ITagRepository _tagRepository;

        public TagAppService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<List<TagDto>> GetPopularTags(Guid blogId, GetPopularTagsInput input)
        {
            var postTags = (await _tagRepository.GetListAsync(blogId)).OrderByDescending(t=>t.UsageCount)
                .WhereIf(input.MinimumPostCount != null, t=>t.UsageCount >= input.MinimumPostCount)
                .Take(input.ResultCount).ToList();

            return new List<TagDto>(
                ObjectMapper.Map<List<Tag>, List<TagDto>>(postTags));
        }
    }
}
