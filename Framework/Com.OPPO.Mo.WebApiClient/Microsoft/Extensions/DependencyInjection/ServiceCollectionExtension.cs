using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiClient;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IHttpClientBuilder AddHttpApi<THttpApi>(this IServiceCollection services,
            Action<HttpApiConfig> httpApiConfigAction = null,
            Action<HttpApiOptions<THttpApi>, IServiceProvider> httpApiOptionConfigAction = null) where THttpApi : class, IHttpApi
        {
            var optionsBuilder = services.AddOptions<HttpApiOptions<THttpApi>>();
            if (httpApiOptionConfigAction != null)
                optionsBuilder.Configure(httpApiOptionConfigAction);
            return services
                .AddHttpClient(typeof(THttpApi).FullName)
                .AddTypedClient((httpClient, serviceProvider) =>
                {
                    var httpApiConfig = new HttpApiConfig(httpClient)
                    {
                        ServiceProvider = serviceProvider
                    };

                    httpApiConfigAction?.Invoke(httpApiConfig);
                    var httpApiOptions = serviceProvider.GetRequiredService<IOptions<HttpApiOptions<THttpApi>>>().Value;
                    MergeOptions(httpApiConfig, httpApiOptions);

#pragma warning disable WA2001 // 慎用的Create函数
                    return HttpApi.Create<THttpApi>(httpApiConfig);
#pragma warning restore WA2001 // 慎用的Create函数
                });
        }

        private static void MergeOptions<THttpApi>(HttpApiConfig httpApiConfig, HttpApiOptions<THttpApi> httpApiOptions) where THttpApi : class, IHttpApi
        {
            if (httpApiOptions.UseParameterPropertyValidate != null)
                httpApiConfig.UseParameterPropertyValidate = httpApiOptions.UseParameterPropertyValidate.Value;

            if (httpApiOptions.UseReturnValuePropertyValidate != null)
                httpApiConfig.UseReturnValuePropertyValidate = httpApiOptions.UseReturnValuePropertyValidate.Value;

            if (httpApiOptions.FormatOptions != null)
                httpApiConfig.FormatOptions = httpApiOptions.FormatOptions;

            if (httpApiOptions.HttpHost != null)
                httpApiConfig.HttpHost = httpApiOptions.HttpHost;

            if (httpApiOptions.JsonFormatter != null)
                httpApiConfig.JsonFormatter = httpApiOptions.JsonFormatter;

            if (httpApiOptions.KeyValueFormatter != null)
                httpApiConfig.KeyValueFormatter = httpApiOptions.KeyValueFormatter;

            if (httpApiOptions.XmlFormatter != null)
                httpApiConfig.XmlFormatter = httpApiOptions.XmlFormatter;

            if (httpApiOptions.ResponseCacheProvider != null)
                httpApiConfig.ResponseCacheProvider = httpApiOptions.ResponseCacheProvider;
        }
    }
}
