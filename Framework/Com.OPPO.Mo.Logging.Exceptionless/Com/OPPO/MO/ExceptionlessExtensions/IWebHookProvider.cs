using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Com.OPPO.Mo.ExceptionlessExtensions
{
    public interface IWebHookProvider : ISingletonDependency
    {
        string Name { get; }

        Task ProcessAsync(ExceptionLessEventModel model, IDictionary<string, string> parameters);
    }
}