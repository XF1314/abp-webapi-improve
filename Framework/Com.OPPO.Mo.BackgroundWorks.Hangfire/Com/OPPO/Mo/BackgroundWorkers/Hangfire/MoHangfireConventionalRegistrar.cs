using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace Com.OPPO.Mo.BackgroundWorkers.Hangfire
{
    public class MoHangfireConventionalRegistrar : DefaultConventionalRegistrar
    {
        public override void AddType(IServiceCollection services, Type type)
        {
            if (!typeof(IHangfireBackgroundWorker).IsAssignableFrom(type))
            {
                return;
            }

            var dependencyAttribute = GetDependencyAttributeOrNull(type);
            var lifeTime = GetLifeTimeOrNull(type, dependencyAttribute);

            if (lifeTime == null)
            {
                return;
            }

            services.Add(ServiceDescriptor.Describe(typeof(IHangfireBackgroundWorker), type, lifeTime.Value));
        }
    }
}
