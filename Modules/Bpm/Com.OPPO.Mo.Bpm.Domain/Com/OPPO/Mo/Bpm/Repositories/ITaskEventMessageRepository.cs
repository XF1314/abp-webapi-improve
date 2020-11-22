using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Com.OPPO.Mo.Bpm.Repositories
{
    /// <summary>
    /// 流程事件消息仓储接口
    /// </summary>
    public interface ITaskEventMessageRepository : IMoBasicRepository<TaskEventMessage, Guid>
    {
    }
}
