using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Com.OPPO.Mo.Bpm;
using Com.OPPO.Mo.Bpm.Mongo;
using Com.OPPO.Mo.Bpm.Repositories;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Volo.Abp.Uow;
using Volo.Abp.Uow.MongoDB;

namespace Com.OPPO.Mo.BpmService.Controllers
{
    [Area("cap")]
    [Route("api/mo/bpm/cap")]
    [Authorize]
    public class CapPublishController : AbpController
    {
        private readonly ICapPublisher _capPublisher;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IConnectionStringResolver _connectionStringResolver;
        private readonly IMongoDbContextProvider<IMoBpmMongoDbContext> _mongoDbContextProvider;
        private readonly ITaskEventMessageRepository _processEventMessageRepository;

        public CapPublishController(ICapPublisher capPublisher,
            IUnitOfWorkManager unitOfWorkManager,
            IConnectionStringResolver connectionStringResolver,
            ITaskEventMessageRepository processEventMessageRepository,
            IMongoDbContextProvider<IMoBpmMongoDbContext> mongoDbContextProvider)
        {
            _capPublisher = capPublisher;
            _unitOfWorkManager = unitOfWorkManager;
            _mongoDbContextProvider = mongoDbContextProvider;
            _connectionStringResolver = connectionStringResolver;
            _processEventMessageRepository = processEventMessageRepository;
        }

        [HttpPost("test/transaction")]
        public async Task<Result> EntityFrameworkWithTransaction()
        {
            var unitOfWork = _unitOfWorkManager.Current;//_capPublisher.Transaction.Value =
            var connectionString = _connectionStringResolver.Resolve<IMoBpmMongoDbContext>();
            var dbContextKey = $"{typeof(IMoBpmMongoDbContext).FullName}_{connectionString}";

           
            var mongoUrl = new MongoUrl(connectionString);
            var databaseName = mongoUrl.DatabaseName;
            if (databaseName.IsNullOrWhiteSpace())
            {
                databaseName = ConnectionStringNameAttribute.GetConnStringName<IMoBpmMongoDbContext>();
            }
            var database = ((IMongoDbRepository<TaskEventMessage>)_processEventMessageRepository).Database;
            var session = _mongoDbContextProvider.GetDbContext().Database.Client.StartSession();

            //MongoDb事务需集群支持（哪怕是单节点）
            ///<see cref="https://blog.csdn.net/zinechina/article/details/104948762"/>
            using (var trans = _mongoDbContextProvider.GetDbContext().Database.Client.StartTransaction(_capPublisher, autoCommit: true))
            {
                //link.mo.bpm.process.event.message
                await _capPublisher.PublishAsync("xxx.services.show.time", DateTime.Now);
            }

            using (var trans = database.Client.StartTransaction(_capPublisher, autoCommit: true))
            {
                //link.mo.bpm.process.event.message
                await _capPublisher.PublishAsync("xxx.services.show.time", DateTime.Now.AddMinutes(60));
            }

            return Result.Ok();
        }

        [HttpPost("test/with-no-transaction")]
        public async Task<Result> WithNoTransaction()
        {
            await _capPublisher.PublishAsync("xxx.services.show.time", DateTime.Now);
            return Result.Ok();
        }

    }
}
