using System;

namespace Com.OPPO.Mo.Blogging.Comments
{
    [Serializable]
    public class CommentEto
    {
        public Guid Id { get; set; }

        public Guid PostId { get; set; }

        public Guid? RepliedCommentId { get; set; }

        public string Text { get; set; }
    }
}