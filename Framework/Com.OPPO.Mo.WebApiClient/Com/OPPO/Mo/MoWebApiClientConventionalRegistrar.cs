using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Volo.Abp.DependencyInjection;
using WebApiClient;

namespace Com.OPPO.Mo
{
    public class MoWebApiClientConventionalRegistrar : DefaultConventionalRegistrar
    {
        public override void AddAssembly(IServiceCollection services, Assembly assembly)
        {
            var types = GetAllTypes(assembly)
                .Where(type => type != null && type.IsInterface && !type.IsGenericType)
                .ToArray();

            AddTypes(services, types);
        }

        public override void AddType(IServiceCollection services, Type type)
        {
            var configuration = services.GetConfiguration();
            if (!typeof(IHttpApi).IsAssignableFrom(type))
            {
                return;
            }

            var name = type.FullName;
            var httpApiFactoryType = typeof(HttpApiFactory<>).MakeGenericType(type);
            var registerMethod = typeof(HttpApi).GetMethod("Register", new[] { typeof(string) });
            var registerGenericMethod = registerMethod.MakeGenericMethod(new Type[] { type });
            var httpApiFactory = (IHttpApiFactory)registerGenericMethod.Invoke(null, new object[] { name });
            services.Add(ServiceDescriptor.Describe(httpApiFactoryType, x => { return httpApiFactory; }, ServiceLifetime.Singleton));
        }

        private static IReadOnlyList<Type> GetAllTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types;
            }
        }
    }
}
