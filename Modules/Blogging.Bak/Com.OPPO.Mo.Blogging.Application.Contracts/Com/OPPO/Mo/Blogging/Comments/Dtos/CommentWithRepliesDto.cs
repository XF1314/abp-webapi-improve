using System.Collections.Generic;

namespace Com.OPPO.Mo.Blogging.Comments.Dtos
{
    public class CommentWithRepliesDto
    {
        public CommentWithDetailsDto Comment { get; set; }

        public List<CommentWithDetailsDto> Replies { get; set; } = new List<CommentWithDetailsDto>();
    }
}
