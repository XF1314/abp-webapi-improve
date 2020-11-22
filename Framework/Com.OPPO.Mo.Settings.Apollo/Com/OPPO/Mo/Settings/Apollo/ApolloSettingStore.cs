using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Settings;

namespace Com.OPPO.Mo.Settings.Apollo
{
    ///// <summary>
    ///// 放弃这种方法，按作者设计思路，应该是实现一个<see cref="ISettingValueProvider"/>对象
    ///// </summary>
    //[Dependency(TryRegister = true)]
    //public class ApolloSettingStore : ISettingStore
    //{
    //    public Task<string> GetOrNullAsync(string name, string providerName, string providerKey)
    //    {
    //        return Task.FromResult((string)null);
    //    }
    //}
}
