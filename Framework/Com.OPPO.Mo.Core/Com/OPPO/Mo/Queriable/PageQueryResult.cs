using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Com.OPPO.Mo.Queriable
{
    /// <summary>
    /// 分页查询结果
    /// </summary>
    public class PageQueryResult<TRecord> : IPageQueryResult
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
        /// 偏移量
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 数据总条数
        /// </summary>
        /// <example>250</example>
        public int TotalCount { get; set; }

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
        /// <see cref="PageQueryResult{TRecord}"/>
        /// </summary>
        public PageQueryResult()
        {
            Data = default;
        }

        /// <summary>
        /// <see cref="PageQueryResult{TRecord}"/>
        /// </summary>
        /// <param name="code"><see cref="ResultCode"/></param>
        /// <param name="records">记录s</param>
        /// <param name="totalCount">总数量</param>
        /// <param name="offset">偏移量</param>
        /// <param name="count">数量</param>
        /// <param name="message"消息</param>
        public PageQueryResult(ResultCode code, IList<TRecord> records, int totalCount, int offset, int count, string message)
        {
            Code = code;
            Data = records;
            TotalCount = totalCount;
            Offset = offset;
            Count = count;
            Data = records;
            Msg = message;
        }

        /// <summary>
        /// <see cref="PageQueryResult{TRecord}"/>
        /// </summary>
        /// <param name="records">记录s</param>
        /// <param name="totalCount">总数量</param>
        /// <param name="offset">偏移量</param>
        /// <param name="count">数量</param>
        public PageQueryResult(IList<TRecord> records, int totalCount, int offset, int count)
        {
            Data = records;
            TotalCount = totalCount;
            Offset = offset;
            Count = count;
            Data = records;
        }

        /// <summary>
        /// <see cref="PageQueryResult{TRecord}"/>
        /// </summary>
        /// <param name="code"><see cref="ResultCode"/></param>
        /// <param name="records">记录s</param>
        /// <param name="totalCount">总数量</param>
        /// <param name="pageInfo"><see cref="IPageInfo"/></param>
        public PageQueryResult(ResultCode code, IList<TRecord> records, int totalCount, IPageInfo pageInfo)
            : this(code, records, totalCount, pageInfo.Offset, pageInfo.Count, string.Empty)
        {
        }

        /// <summary>
        /// <see cref="PageQueryResult{TRecord}"/>
        /// </summary>
        /// <param name="records">记录s</param>
        /// <param name="totalCount">总数量</param>
        /// <param name="pageInfo"><see cref="IPageInfo"/></param>
        public PageQueryResult(IList<TRecord> records, int totalCount, IPageInfo pageInfo) : this(records, totalCount, pageInfo.Offset, pageInfo.Count)
        {
        }

        /// <summary>
        /// <see cref="PageQueryResult{TRecord}"/>
        /// </summary>
        /// <param name="code"><see cref="ResultCode"/></param>
        /// <param name="message">消息</param>
        public PageQueryResult(ResultCode code, string message = null)
        {
            Code = code;
            Msg = message;
        }
    }

    public class PageQueryResult : PageQueryResult<object>
    {
        /// <summary>
        /// 返回<see cref="ResultCode"/>
        /// </summary>
        public static PageQueryResult<TData> FromCode<TData>(ResultCode code, string message = null)
        {
            return new PageQueryResult<TData>(code, message);
        }

        /// <summary>
        /// 返回<see cref="ResultCode"/>并相应的信息与数据
        /// </summary>
        public static PageQueryResult<TData> FromCode<TData>(ResultCode code, IList<TData> records, int totalCount, int offset, int count, string message = null)
        {
            return new PageQueryResult<TData>(code, records, totalCount, offset, count, message);
        }

        /// <summary>
        /// 返回异常信息
        /// </summary>
        public static PageQueryResult<TData> FromError<TData>(string message, ResultCode code = ResultCode.Fail)
        {
            return new PageQueryResult<TData>(code, message);
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        public static PageQueryResult<TData> FromData<TData>(IList<TData> records, int totalCount, int offset, int count)
        {
            return new PageQueryResult<TData>(records, totalCount, offset, count);
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        public static PageQueryResult<TData> FromData<TData>(IList<TData> records, int totalCount, IPageInfo pageInfo)
        {
            return new PageQueryResult<TData>(records, totalCount, pageInfo);
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        public static PageQueryResult<TData> Ok<TData>(IList<TData> records, int totalCount, IPageInfo pageInfo)
        {
            return FromData(records, totalCount, pageInfo);
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        public static PageQueryResult<TData> Ok<TData>(IList<TData> records, int totalCount, int offset, int count)
        {
            return FromData(records, totalCount, offset, count);
        }

    }


    /// <summary>
    /// 分页查询结果
    /// </summary>
    public interface IPageQueryResult : IPageInfo
    {
        /// <summary>
        /// 总数
        /// </summary>
        int TotalCount { get; set; }
    }
}
