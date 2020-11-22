using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Com.OPPO.Mo.Bpm.Repositories
{
    /// <summary>
    /// 任务回调配置仓储接口
    /// </summary>
    public interface ITaskCallbackConfigurationRepository : IMoBasicRepository<TaskCallbackConfiguration, Guid>
    {


    }
}
