using System;

namespace Com.OPPO.Mo.MasterData.Process.DbModel
{
    public sealed class PendingProcessInstanceDetail : ProcessInstanceDetail
    {
        public string ProcessInstanceCode { get; set; }

        public string Title { get; set; }

        public string CreatorCode { get; set; }

        public string CreatorZhName { get; set; }

        public string CreatorEnName { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ArrivedAt { get; set; }

        public string ApproverCode { get; set; }

        public string ApproverZhName { get; set; }

        public string ApproverEnName { get; set; }
    }
}