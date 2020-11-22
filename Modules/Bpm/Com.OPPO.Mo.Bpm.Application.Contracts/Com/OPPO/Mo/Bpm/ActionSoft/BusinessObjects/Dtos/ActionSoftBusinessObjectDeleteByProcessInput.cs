﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos
{
    /// <summary>
    /// ActionSoft业务对象按流程删除Input
    /// </summary>
    public class ActionSoftBusinessObjectDeleteByProcessInput
    {
        /// <summary>
        /// 【必填项】业务对象表名称
        /// </summary>
        [JsonRequired]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 【必填项】绑定的流程实例Id
        /// </summary>
        [JsonRequired]
        public string ProcessInstanceId { get; set; }
    }
}
