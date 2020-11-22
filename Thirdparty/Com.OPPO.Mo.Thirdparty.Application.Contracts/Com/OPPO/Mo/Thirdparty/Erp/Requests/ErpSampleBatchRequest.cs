namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// PLM获取ERP样品库同步处理结果信息查询信息
    /// </summary>
    public class ErpSampleBatchRequest : BaseEsbRequest
    {
        /// <summary>
        /// 批次
        /// </summary>
        public string BatchId { get; set; }
    }
}
