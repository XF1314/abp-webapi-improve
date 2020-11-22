using System.Runtime;

namespace Com.OPPO.Mo
{
    /// <summary>
    /// 返回结果
    /// </summary>
    public class Result : IResult
    {
        public const string Successfull = "Success";
        private string _message;

        /// <summary>
        /// 返回结果
        /// </summary>
        public Result() { }

        /// <summary>
        /// 返回结果
        /// </summary>
        /// <param name="code"><see cref="ResultCode"/></param>
        /// <param name="message">提示信息</param>
        public Result(ResultCode code, string message = null)
        {
            Code = code;
            Msg = message;
        }

        /// <summary>
        /// 结果状态码
        /// </summary>
        public ResultCode Code { get; set; }

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

        #region 静态函数
        /// <summary>
        /// 返回<see cref="ResultCode"/>
        /// </summary>
        public static Result FromCode(ResultCode code, string message = null)
        {
            return new Result(code, message);
        }

        /// <summary>
        /// 返回<see cref="ResultCode"/>
        /// </summary>
        public static Result<TData> FromCode<TData>(ResultCode code, string message = null)
        {
            return new Result<TData>(code, message);
        }

        /// <summary>
        /// 返回<see cref="ResultCode"/>并相应的信息与数据
        /// </summary>
        /// <typeparam name="TData">数据类型</typeparam>
        /// <param name="code"><see cref="ResultCode"/></param>
        /// <param name="message">信息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static Result<TData> FromCode<TData>(ResultCode code, TData data, string message = null)
        {
            return new Result<TData>(code, message, data);
        }

        /// <summary>
        /// 返回异常信息
        /// </summary>
        public static Result FromError(string message, ResultCode code = ResultCode.Fail)
        {
            return new Result(code, message);
        }

        /// <summary>
        /// 返回异常信息
        /// </summary>
        public static Result<TData> FromError<TData>(string message, ResultCode code = ResultCode.Fail)
        {
            return new Result<TData>(code, message);
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        public static Result<TData> FromData<TData>(TData data)
        {
            return new Result<TData>(data);
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        public static Result<TData> FromData<TData>(TData data, string message)
        {
            return new Result<TData>(ResultCode.Ok, message, data);
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        public static Result Ok(string message = null)
        {
            return FromCode(ResultCode.Ok, message);
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        public static Result<TData> Ok<TData>(TData data)
        {
            return FromData(data);
        }

        #endregion
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class Result<TData> : Result, IResult<TData>
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public Result() { }

        /// <summary>
        /// 返回结果
        /// </summary>
        public Result(TData data) : base(ResultCode.Ok)
        {
            Data = data;
        }

        /// <summary>
        /// 返回结果
        /// </summary>
        /// <param name="code"><see cref="ResultCode"/></param>
        /// <param name="message">信息</param>
        public Result(ResultCode code, string message = null)
            : base(code, message)
        {

        }

        /// <summary>
        /// 返回结果
        /// </summary>
        /// <param name="code"><see cref="ResultCode"/></param>
        /// <param name="message">信息</param>
        /// <param name="data">数据</param>
        public Result(ResultCode code, string message = null, TData data = default(TData))
          : base(code, message)
        {
            Data = data;
        }

        /// <summary>
        /// 结果数据
        /// </summary>
        public TData Data { get; set; }
    }
}
