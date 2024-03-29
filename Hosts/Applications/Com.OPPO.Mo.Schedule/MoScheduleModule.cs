﻿using Com.OPPO.Mo.BackgroundWorkers.Hangfire;
using Com.OPPO.Mo.ExceptionlessExtensions;
using Com.OPPO.Mo.Identity;
using Com.OPPO.Mo.MasterData;
using Com.OPPO.Mo.Schedule.CapSubscribe;
using Com.OPPO.Mo.Schedule.Custom;
using Com.OPPO.Mo.Settings.Apollo;
using Hangfire;
using Hangfire.Client;
using Hangfire.Common;
using Hangfire.Redis;
using Hangfire.Server;
using Hangfire.States;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Com.OPPO.Mo.Schedule
{
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(AbpAspNetCoreModule))]
    [DependsOn(typeof(MoExceptionlessModule))]
    [DependsOn(typeof(AbpHttpClientIdentityModelModule))]
    [DependsOn(typeof(AbpBackgroundJobsHangfireModule))]
    [DependsOn(typeof(MoMasterDataHttpApiClientModule))]
    [DependsOn(typeof(MoIdentityHttpApiClientModule))]
    [DependsOn(typeof(MoSettinsApolloModule))]
    [DependsOn(typeof(MoBackgroundWorkersHangfireModule))]
    public class MoScheduleModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            Configure<AbpLocalizationOptions>(options => options.Languages.Add(new LanguageInfo("en", "en", "English")));
            context.Services.AddStackExchangeRedisCache(options => options.Configuration = configuration["Redis:Configuration"]);

            context.Services.AddHostedService<DemoRecurringJobHostedService>();
            context.Services.Configure<HostOptions>(option => option.ShutdownTimeout = TimeSpan.FromSeconds(60));
            context.Services.TryAddSingleton(new RedisStorageOptions
            {
                InvisibilityTimeout = TimeSpan.FromMinutes(5),
                Db = 15,
                ExpiryCheckInterval = TimeSpan.FromMinutes(30),
                SucceededListSize = 2000,
                DeletedListSize = 1000
            });

            context.Services.TryAddSingleton<IBackgroundJobFactory>(x =>
                 new TrackedBackgroundJobFactory(new BackgroundJobFactory(x.GetRequiredService<IJobFilterProvider>())));
            context.Services.AddCap(x =>
            {
                x.UseDashboard();
                x.UseMongoDB(x =>
                {
                    x.DatabaseConnection = configuration["ConnectionStrings:Default"];
                    x.DatabaseName = "ScheduleCap";
                });
                x.UseKafka("10.176.8.23:9092,10.176.8.24:9092,10.176.11.30:9092");
                //x.UseRabbitMQ(x =>
                //{
                //    x.HostName = configuration["RabbitMQ:HostName"];
                //    x.UserName = configuration["RabbitMQ:UserName"];
                //    x.Password = configuration["RabbitMQ:Password"];
                //});
            });

            context.Services.TryAddSingleton<IBackgroundJobPerformer>(x =>
                new TrackedBackgoundJobPerformer(new BackgroundJobPerformer(
                    x.GetRequiredService<IJobFilterProvider>(),
                    x.GetRequiredService<JobActivator>(),
                    TaskScheduler.Default)));

            context.Services.TryAddSingleton<IBackgroundJobStateChanger>(x =>
                new TrackedBackgroundJobStateChanger(new BackgroundJobStateChanger(x.GetRequiredService<IJobFilterProvider>())));

            var connectionMultiplexer = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            context.Services.AddDataProtection()
                .PersistKeysToStackExchangeRedis(connectionMultiplexer, "Mo-DataProtection-Keys-Schedule");
            context.Services.AddHangfire((provider, configuration) => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRedisStorage(connectionMultiplexer, provider.GetRequiredService<RedisStorageOptions>()));
            context.Services.AddHangfireServer(options =>
            {
                options.StopTimeout = TimeSpan.FromSeconds(5);
                options.ShutdownTimeout = TimeSpan.FromSeconds(30);
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseHangfireServer();
            app.UseHangfireDashboard(pathMatch: "/hangfire");
            app.UseRouting();
            app.UseAbpRequestLocalization();
        }
    }
}
