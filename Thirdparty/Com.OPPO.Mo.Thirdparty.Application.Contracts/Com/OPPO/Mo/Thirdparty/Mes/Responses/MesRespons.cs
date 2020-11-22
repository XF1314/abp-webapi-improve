using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Com.OPPO.Mo.Thirdparty.Mes.Responses
{
    public class MesRespons
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOk { get { return Code == "0"; } }

    }

    /// <inheritdoc/>
    public class MesRespons<TData> : MesRespons
    {
        /// <summary>
        /// <see cref="MesRespons{TData}"/>
        /// </summary>
        public MesRespons()
        {
            Data = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        [JsonProperty("response")]
        public MesResponsDataBase<TData> Data { get; set; }
    }

    /// <inheritdoc/>
    public class MesResponsDataBase<TData>
    {
        /// <summary>
        /// <see cref="MesResponsDataBase{TData}"/>
        /// </summary>
        public MesResponsDataBase()
        {
            Data = default;
        }

        /// <summary>
        /// 总行数
        /// </summary>
        [JsonProperty("total_results")]
        public int TotalAcount { get; set; }


        /// <summary>
        /// 响应内容
        /// </summary>
        [JsonProperty("model_info")]
        public TData Data { get; set; }
    }
}
