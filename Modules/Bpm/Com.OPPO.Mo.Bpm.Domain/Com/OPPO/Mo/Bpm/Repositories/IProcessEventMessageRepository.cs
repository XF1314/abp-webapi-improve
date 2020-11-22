using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Repositories
{
    /// <summary>
    /// 任务事件消息仓储接口
    /// </summary>
    public interface IProcessEventMessageRepository : IMoBasicRepository<ProcessEventMessage, Guid>
    {
    }
}
