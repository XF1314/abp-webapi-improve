using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Com.OPPO.Mo.Blogging.Comments.Dtos;

namespace Com.OPPO.Mo.Blogging.Comments
{
    public interface ICommentAppService : IApplicationService
    {
        Task<List<CommentWithRepliesDto>> GetHierarchicalListOfPostAsync(Guid postId);

        Task<CommentWithDetailsDto> CreateAsync(CreateCommentDto input);

        Task<CommentWithDetailsDto> UpdateAsync(Guid id, UpdateCommentDto input);

        Task DeleteAsync(Guid id);
    }
}
