using System;
using Volo.Abp.Application.Dtos;
using Com.OPPO.Mo.Blogging.Posts;

namespace Com.OPPO.Mo.Blogging.Comments.Dtos
{
    public class CommentWithDetailsDto : FullAuditedEntityDto<Guid>
    {
        public Guid? RepliedCommentId { get; set; }

        public string Text { get; set; }

        public BlogUserDto Writer { get; set; }
    }
}
