using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 抛送报销信息头部至ERP 输入参数
    /// </summary>
    public class OnePluesHeardToErpInput
    {
        /// <summary>
        /// json格式： [{ "sourceHeaderId":"93937", "ouId":"81", "ouName":"YJ", "transType":"PayExpense", "transDate":"2018-04-17 15:43:04", "oaNumber":"BX-20180326-219", "employNumber":"601603", "employName":"方永涛Into.Fang", "transAmount":"287.5", "currencyCode":"CNY", "termsName":"", "comments":"方永涛加班打车费用-6次加班打车费用", "sourceCode":"CUXOA", "bankName":"招商银行", "bankDetailName":"南油支行", "bankAccount":"方永涛", "bankAccountNumber":"6214867817970628", "refDoc":"", "status":"NEW", "errorDesc":"The name of the bank does not exist.", "syncFlag":"E", "lastUpdateDate":"2018-07-17 15:29:02", "lastUpdatedBy":"2341", "lastUpdateLogin":"2341", "creationDate":"2018-04-17 15:43:04", "createdDy":"-1" }]
        /// </summary>
        [Required]
        public string Lines { get; set; }

        /// <summary>
        /// 返回格式，支持json/xml两种格式，默认为json格式
        /// </summary>
        [JsonIgnore]
        public string RespType { get; set; }
    }
}
