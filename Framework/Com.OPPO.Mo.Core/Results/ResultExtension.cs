using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.OPPO.Mo
{
    public static class ResultExtension
    {
        /// <summary>
        /// 是否为成功状态
        /// </summary>
        public static bool IsOk(this IResult result)
        {
            return result?.Code == 0;
        }

        /// <summary>
        /// 返回结果数据
        /// </summary>
        public static async Task<Result<T>> ToResultAsync<T>(this Task<T> data)
        {
            return Result.FromData(await data);
        }

    }
}