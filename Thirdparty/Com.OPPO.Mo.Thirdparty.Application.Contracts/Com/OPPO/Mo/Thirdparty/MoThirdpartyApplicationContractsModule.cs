using Com.OPPO.Mo.Thirdparty.Adap;
using Com.OPPO.Mo.Thirdparty.Common.EmailSend;
using Com.OPPO.Mo.Thirdparty.DataGrand;
using Com.OPPO.Mo.Thirdparty.DataGrand.Services;
using Com.OPPO.Mo.Thirdparty.DiDi;
using Com.OPPO.Mo.Thirdparty.DiDi.Services;
using Com.OPPO.Mo.Thirdparty.Erp.ErpBasics;
using Com.OPPO.Mo.Thirdparty.Erp.ErpOrder;
using Com.OPPO.Mo.Thirdparty.Erp.ErpSrm;
using Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp;
using Com.OPPO.Mo.Thirdparty.Erp.Services;
using Com.OPPO.Mo.Thirdparty.Fdc;
using Com.OPPO.Mo.Thirdparty.Feiheair;
using Com.OPPO.Mo.Thirdparty.Feiheair.Services;
using Com.OPPO.Mo.Thirdparty.Hio.Services;
using Com.OPPO.Mo.Thirdparty.Hr.LMS.Service;
using Com.OPPO.Mo.Thirdparty.Hr.Public;
using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Service;
using Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform;
using Com.OPPO.Mo.Thirdparty.Hr.PsHr;
using Com.OPPO.Mo.Thirdparty.Hr.Rewar;
using Com.OPPO.Mo.Thirdparty.Hr.Services;
using Com.OPPO.Mo.Thirdparty.Jms;
using Com.OPPO.Mo.Thirdparty.Localization;
using Com.OPPO.Mo.Thirdparty.Megvii;
using Com.OPPO.Mo.Thirdparty.Mes.Services;
using Com.OPPO.Mo.Thirdparty.Ocsm.Services;
using Com.OPPO.Mo.Thirdparty.OTravel;
using Com.OPPO.Mo.Thirdparty.RealmeOpenApi.Services;
using Com.OPPO.Mo.Thirdparty.Sms;
using Com.OPPO.Mo.Thirdparty.Sms.Services;
using Com.OPPO.Mo.Thirdparty.Upm;
using Com.OPPO.Mo.Thirdparty.Visitors;
using Com.OPPO.Mo.Thirdparty.Wifi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Volo.Abp;
using Volo.Abp.Application;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using WebApiClient;
using Com.OPPO.Mo.Thirdparty.Erp.ErpAssets;
using Com.OPPO.Mo.Thirdparty.Erp.ErpEam;
using Com.OPPO.Mo.Thirdparty.Plm;
using Com.OPPO.Mo.Thirdparty.TeamTalk;
using Com.OPPO.Mo.Thirdparty.Wifi;
using Com.OPPO.Mo.Thirdparty.OnePlus;
using Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets;
using Com.OPPO.Mo.Thirdparty.DataReview;
using Com.OPPO.Mo.Thirdparty.OnePlus.PS;
using Com.OPPO.Mo.Thirdparty.Paas;

namespace Com.OPPO.Mo.Thirdparty
{
    [DependsOn(typeof(MoCoreModule))]
    [DependsOn(typeof(MoWebApiClientModule))]
    [DependsOn(typeof(AbpDddApplicationModule))]
    public class MoThirdpartyApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options => options.FileSets.AddEmbedded<MoThirdpartyApplicationContractsModule>());
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<MoThirdpartyResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Com/OPPO/Mo/Thirdparty/Localization/Resources");
            });
            Configure<AbpExceptionLocalizationOptions>(options => options.MapCodeNamespace("Com.OPPO.Mo.Thirdparty", typeof(MoThirdpartyResource)));

            var configuration = context.Services.GetRequiredServiceLazy<IConfiguration>();
            var loggerFactory = context.Services.GetRequiredServiceLazy<ILoggerFactory>();
            var moWebApiClientLogFilter = new MoWebApiClientLogFilter(loggerFactory);

            RegisterJmsServices(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterEsbServices(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterDataGrandServices(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterOcsmService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterRealmeOpenApiService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterErpService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterMesExportSoftwareInfoAppService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterSmsService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterWifiService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterMegviiAppService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterRewaPushAppService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterLmsAppService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterLmsWebApiAppService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterOTravelAppService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterAdapAppService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterFdcAppService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterDiDoAppService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterFeiHeairAppService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterDataReviewAppService(context, configuration, loggerFactory, moWebApiClientLogFilter);
            RegisterEmailService(context, configuration, loggerFactory, moWebApiClientLogFilter);

            RegisterPaasService(context, moWebApiClientLogFilter);
        }

        private static void RegisterPaasService(ServiceConfigurationContext context, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            context.Services.AddHttpApi<IPaasAuthenticationWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
            });
        }

        private static void RegisterEmailService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var esbParamsSignatureFilter = new EsbParamsSignatureToEmailFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IEmailSendWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParamsSignatureFilter);
            });
        }

        private void RegisterDataReviewAppService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            context.Services.AddHttpApi<IDataReviewWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
            });
        }

        private void RegisterFeiHeairAppService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var diParamSignatureFilter = new FeHeiairParamsSignatureFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IFeiHeairServiceWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(diParamSignatureFilter);
            });
            
        }

        private void RegisterDiDoAppService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var diParamSignatureFilter = new DiDiParamSignatureFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IDiDiServiceWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(diParamSignatureFilter);
            });
        }

        private void RegisterLmsWebApiAppService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var esbParamsSignatureFilter = new LmsParamSignatureFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<ILmsWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParamsSignatureFilter);
            });
        }

        private void RegisterLmsAppService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var esbParamsSignatureFilter = new EsbLmsParamSignatureFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IPeopleSofLmsService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParamsSignatureFilter);
            });
        }

        private void RegisterRewaPushAppService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var rewarSignatureFilter = new RewarSignatureFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IRewardPushWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(rewarSignatureFilter);
            });
        }

        private void RegisterFdcAppService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var megviiFilter = new FdcSignaturnFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IFinanceExpenseWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(megviiFilter);
            });
        }

        private void RegisterAdapAppService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var megviiFilter = new AdapFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IAdapWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(megviiFilter);
            });
        }

        private void RegisterOTravelAppService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var megviiFilter = new OTravelFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IOTravelWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(megviiFilter);
            });
        }

        private void RegisterMegviiAppService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var megviiFilter = new MegviiFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IMegviiWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(megviiFilter);
            });
        }

        private void RegisterWifiService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var smsParamsSignatureFilter = new H3cParamsSignatureFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IWifiWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(smsParamsSignatureFilter);
            });
        }

        private void RegisterSmsService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var smsParamsSignatureFilter = new SmsParamsSignatureFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<ISmsWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(smsParamsSignatureFilter);
            });
        }

        private void RegisterMesExportSoftwareInfoAppService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var esbParameterSignFilter = new EsbParamsSignatureFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IMesExportSoftwareInfoEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });
        }

        private void RegisterErpService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var esbParameterSignFilter = new EsbParamsSignatureFilter(loggerFactory, configuration);

            context.Services.AddHttpApi<IErpEamEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });
            context.Services.AddHttpApi<IErpServiceInfoEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });
            context.Services.AddHttpApi<IErpBasicDataEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });
            context.Services.AddHttpApi<IErpAssestEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });
            context.Services.AddHttpApi<IErpAssetsService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });
            context.Services.AddHttpApi<IErpCallbackEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });

            context.Services.AddHttpApi<IErpEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });
            context.Services.AddHttpApi<IErpOrderEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });
            context.Services.AddHttpApi<IErpSrmEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });
            context.Services.AddHttpApi<IErpBasicsEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });

            context.Services.AddHttpApi<IHioWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });
            context.Services.AddHttpApi<IErpExpenseReimbursementEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });
            context.Services.AddHttpApi<IOnePlusErpEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });
            context.Services.AddHttpApi<IOnePlusErpAssetsEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });
            context.Services.AddHttpApi<IOnePlusPsEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParameterSignFilter);
            });
        }

        private static void RegisterRealmeOpenApiService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var realmeOpenApiParamsSignatureFilter = new RealmeOpenApiParamsSignatureFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IRealmeBrushToolsCompileInfoWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(realmeOpenApiParamsSignatureFilter);
            });
        }

        private static void RegisterOcsmService(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var ocsmParamsSignatureFilter = new OcsmParamsSignatureFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IOcsmBrushToolCompileInfoWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(ocsmParamsSignatureFilter);
            });
        }

      

        private static void RegisterEsbServices(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {

            var esbParamsSignatureFilter = new EsbParamsSignatureFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IOnePlusEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParamsSignatureFilter);
            });
           
            context.Services.AddHttpApi<ILeaveBatchWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParamsSignatureFilter);
            });

            context.Services.AddHttpApi<ITeamTalkEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParamsSignatureFilter);
            });
            context.Services.AddHttpApi<IPlmEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParamsSignatureFilter);
            });
            context.Services.AddHttpApi<IVisitorsApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParamsSignatureFilter);
            });

            context.Services.AddHttpApi<IMesExportSoftwareInfoEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParamsSignatureFilter);
            });


            context.Services.AddHttpApi<IMesEsbService>(x =>
           {
               x.FormatOptions.UseCamelCase = true;
               x.GlobalFilters.Add(moWebApiClientLogFilter);
               x.GlobalFilters.Add(esbParamsSignatureFilter);
           });

            context.Services.AddHttpApi<IUpmEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParamsSignatureFilter);
            });

            context.Services.AddHttpApi<IOcsmBrushToolCompileInfoEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParamsSignatureFilter);
            });

            var preParamsSignatureFilter = new PreEmploymentSignatureFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IPreEmploymentWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(preParamsSignatureFilter);
            });
            context.Services.AddHttpApi<IPeopleSoftEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParamsSignatureFilter);
            });
            context.Services.AddHttpApi<IPeopleSoftPublicEsbService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(esbParamsSignatureFilter);
            });
            
            var peopleSoftHrParamsFilter = new PeopleSoftHrParamsFilter(loggerFactory, configuration);
            context.Services.AddHttpApi<IHrPsWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(peopleSoftHrParamsFilter);
            });
        }

        private static void RegisterDataGrandServices(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            var dataGrandSoftParamsSignFilter = new DataGrandParamsSignatureFilter(configuration, loggerFactory);
            context.Services.AddHttpApi<IDataGrandDataSearchWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(dataGrandSoftParamsSignFilter);
            });
            context.Services.AddHttpApi<IDataGrandArticleDataWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(dataGrandSoftParamsSignFilter);
            });
            context.Services.AddHttpApi<IDataGrandMailDataWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(dataGrandSoftParamsSignFilter);
            });
            context.Services.AddHttpApi<IDataGrandModuleDataWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(dataGrandSoftParamsSignFilter);
            });
            context.Services.AddHttpApi<IDataGrandPermissionWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(dataGrandSoftParamsSignFilter);
            });
            context.Services.AddHttpApi<IDataGrandSuggestionWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(dataGrandSoftParamsSignFilter);
            });
            context.Services.AddHttpApi<IDataGrandUserBehaviorWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
                x.GlobalFilters.Add(dataGrandSoftParamsSignFilter);
            });
        }

        private static void RegisterJmsServices(ServiceConfigurationContext context, Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory, MoWebApiClientLogFilter moWebApiClientLogFilter)
        {
            context.Services.AddHttpApi<IJmsProductInfoWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
            });
            context.Services.AddHttpApi<IJmsServiceInfoWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
            });
            context.Services.AddHttpApi<IJmsBusinessInfoWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
            });
            context.Services.AddHttpApi<IJmsHostInfoWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
            });
            context.Services.AddHttpApi<IJmsModuleInfoWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
            });
            context.Services.AddHttpApi<IJmsPermissionWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
            });
            context.Services.AddHttpApi<IJmsCallbackWebApiService>(x =>
            {
                x.FormatOptions.UseCamelCase = true;
                x.GlobalFilters.Add(moWebApiClientLogFilter);
            });

        }
    }
}
