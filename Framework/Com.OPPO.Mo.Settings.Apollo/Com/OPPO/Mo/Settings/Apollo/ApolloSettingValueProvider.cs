using Com.Ctrip.Framework.Apollo;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Settings;

namespace Com.OPPO.Mo.Settings.Apollo
{
    /// <summary>
    /// 需要注意添加顺序，应该在<see cref="ConfigurationSettingValueProvider"/>之后，<see cref=" DefaultValueSettingValueProvider"/>之前
    /// </summary>
    public class ApolloSettingValueProvider : ISettingValueProvider, ITransientDependency
    {
        public string Name => "A";

        protected IConfiguration Configuration { get; }

        public ApolloSettingValueProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual async Task<string> GetOrNullAsync(SettingDefinition setting)
        {
            var keys = setting.Name.Split(ConfigurationPath.KeyDelimiter, StringSplitOptions.RemoveEmptyEntries);
            if (keys.Length > 0)
            {
                var @namespace = keys[0];
                //if (ApolloConfigurationManager.Manager.Registry.GetFactory(@namespace) != null)
                //{
                    return Configuration[setting.Name];
                //}
            }

            return null;          
        }
    }
}
