using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos
{
    /// <summary>
    /// 简化的ActionSoft流程Dto
    /// </summary>
    public class ActionSoftSimplifiedProcessDto
    {
        /// <summary>
        /// 流程实例Id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 流程定义Id
        /// </summary>
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 流程实例编码
        /// </summary>
        public string ProcessInstanceCode { get; set; }

        /// <summary>
        /// 流程标题
        /// </summary>
        public string ProcessTitle { get; set; }

        /// <summary>
        /// 流程备注信息
        /// </summary>
        public string ProcessRemark { get; set; }

        /// <summary>
        /// 启动时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 创建人用户工号
        /// </summary>
        public string CreatorUserCode { get; set; }

        /// <summary>
        /// 创建人部门编号
        /// </summary>
        public string CreatorDepartmentCode { get; set; }

        /// <summary>
        /// 创建人组织编码
        /// </summary>
        public string CreatorOrganizationCode { get; set; }

        /// <summary>
        /// 流程组Id
        /// </summary>
        public string ProcessGroupId { get; set; }

        /// <summary>
        /// <see cref="ActionSoftProcessControlState"/>
        /// </summary>
        public string ControlState { get; set; }

        /// <summary>
        /// 流程业务状态<see cref="ActionSoftProcessState"/>
        /// </summary>
        public string ProcessState { get; set; }

        /// <summary>
        /// 流程所属业务域分类，Instance Of Business Domain
        /// </summary>
        public string BusinessDomainClassify { get; set; }

        /// <summary>
        /// 流程所属自定义分类，Instance Of Customize
        /// </summary>
        public string CustomizeClassify { get; set; }

        /// <summary>
        /// 流程所属组织区域分类，Instance Of Regional
        /// </summary>
        public string RegionalClassify { get; set; }

        /// <summary>
        /// 流程所属系统分类，Instance Of System
        /// </summary>
        public string SystemClassify { get; set; }
    }
}
