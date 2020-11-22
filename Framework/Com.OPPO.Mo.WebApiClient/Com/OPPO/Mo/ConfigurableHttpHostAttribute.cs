using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Com.OPPO.Mo
{
    public class ConfigurableHttpHostAttribute : ApiActionAttribute
    {
        public string HostName { get; }

        public override int OrderIndex
        {
            get => int.MinValue;
        }

        public ConfigurableHttpHostAttribute(string hostName)
        {
            HostName = hostName;
        }

        public override Task BeforeRequestAsync(ApiActionContext context)
        {
            var configuration = context.GetService<IConfiguration>();
            var host = configuration[HostName];
            if (context.RequestMessage.RequestUri == null)
            {
                context.RequestMessage.RequestUri = new Uri(host, UriKind.Absolute);
            }

            return Task.CompletedTask;
        }
    }
}
