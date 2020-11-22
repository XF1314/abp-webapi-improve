using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;

namespace Com.OPPO.Mo.Queriable
{
    /// <summary>
    /// 查询结果
    /// </summary>
    public class QueryResult<TRecord>
    {
        public const string Successfull = "Success";
        private string _message;

        /// <summary>
        /// 结果状态码
        /// </summary>
        public ResultCode Code { get; set; } = ResultCode.Ok;

        /// <summary>
        /// 结果数据
        /// </summary>
        public IList<TRecord> Data { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        /// <example>操作成功</example>
        public string Msg
        {
            get { return _message ?? Code.DisplayName(); }
            set { _message = value; }
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess => Code == ResultCode.Ok;

        /// <summary>
        /// <see cref="QueryResult{TRecord}"/>
        /// </summary>
        public QueryResult()
        {
            Data = new List<TRecord>();
        }

        /// <summary>
        /// <see cref="QueryResult{TRecord}"/>
        /// </summary>
        public QueryResult(IList<TRecord> records)
        {
            Data = records;
        }

        /// <summary>
        /// <see cref="QueryResult{TRecord}"/>
        /// </summary>
        /// <param name="code"><see cref="ResultCode"/></param>
        /// <param name="message">提示信息</param>
        public QueryResult(ResultCode code, string message = null)
        {
            Code = code;
            Msg = message;
            Data = new List<TRecord>();
        }

        /// <summary>
        /// <see cref="QueryResult{TRecord}"/>
        /// </summary>
        /// <param name="code"><see cref="ResultCode"/></param>
        /// <param name="records"></param>
        /// <param name="message"></param>
        public QueryResult(ResultCode code, IList<TRecord> records, string message = null)
        {
            Code = code;
            Data = records;
            Msg = message;
        }
    }


    public class QueryResult : QueryResult<object>
    {
        /// <summary>
        /// 返回<see cref="ResultCode"/>
        /// </summary>
        public static QueryResult<TData> FromCode<TData>(ResultCode code, string message = null)
        {
            return new QueryResult<TData>(code, message);
        }

        /// <summary>
        /// 返回<see cref="ResultCode"/>并相应的信息与数据
        /// </summary>
        public static QueryResult<TData> FromCode<TData>(ResultCode code, IList<TData> records, string message = null)
        {
            return new QueryResult<TData>(code, records, message);
        }

        /// <summary>
        /// 返回异常信息
        /// </summary>
        public static QueryResult<TData> FromError<TData>(string message, ResultCode code = ResultCode.Fail)
        {
            return new QueryResult<TData>(code, message);
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        public static QueryResult<TData> FromData<TData>(IList<TData> records)
        {
            return new QueryResult<TData>(records);
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        public static QueryResult<TData> FromData<TData>(IList<TData> records, string message)
        {
            return new QueryResult<TData>(ResultCode.Ok, records, message);
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        public static QueryResult<TData> Ok<TData>(IList<TData> records)
        {
            return FromData(records);
        }
    }
}
