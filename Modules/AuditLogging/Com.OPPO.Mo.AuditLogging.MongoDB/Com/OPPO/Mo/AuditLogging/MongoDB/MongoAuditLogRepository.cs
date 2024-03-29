﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.AuditLogging.MongoDB
{
    public class MongoAuditLogRepository : MongoDbRepository<IAuditLoggingMongoDbContext, AuditLog, Guid>, IAuditLogRepository
    {
        public MongoAuditLogRepository(IMongoDbContextProvider<IAuditLoggingMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<AuditLog>> GetListAsync(
            string sorting = null,
            int maxResultCount = 50, 
            int skipCount = 0,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string httpMethod = null,
            string url = null,
            string userName = null,
            string applicationName = null,
            string correlationId = null,
            int? maxDuration = null,
            int? minDuration = null,
            bool? hasException = null,
            HttpStatusCode? httpStatusCode = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            var query = GetListQuery(
                startTime,
                endTime,
                httpMethod,
                url,
                userName,
                applicationName,
                correlationId,
                maxDuration,
                minDuration,
                hasException,
                httpStatusCode,
                includeDetails
            );

            return await query.OrderBy(sorting ?? "executionTime desc").As<IMongoQueryable<AuditLog>>()
                .PageBy<AuditLog, IMongoQueryable<AuditLog>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<long> GetCountAsync(
            DateTime? startTime = null,
            DateTime? endTime = null,
            string httpMethod = null,
            string url = null,
            string userName = null,
            string applicationName = null,
            string correlationId = null,
            int? maxDuration = null,
            int? minDuration = null,
            bool? hasException = null,
            HttpStatusCode? httpStatusCode = null,
            CancellationToken cancellationToken = default)
        {
            var query = GetListQuery(
                startTime,
                endTime,
                httpMethod,
                url,
                userName,
                applicationName,
                correlationId,
                maxDuration,
                minDuration,
                hasException,
                httpStatusCode
            );

            var count = await query.As<IMongoQueryable<AuditLog>>()
                .LongCountAsync(GetCancellationToken(cancellationToken));

            return count;
        }

        protected virtual IQueryable<AuditLog> GetListQuery(
            DateTime? startTime = null,
            DateTime? endTime = null,
            string httpMethod = null,
            string url = null,
            string userName = null,
            string applicationName = null,
            string correlationId = null,
            int? maxDuration = null,
            int? minDuration = null,
            bool? hasException = null,
            HttpStatusCode? httpStatusCode = null,
            bool includeDetails = false)
        {
            return GetMongoQueryable()
                .WhereIf(startTime.HasValue, auditLog => auditLog.ExecutionTime >= startTime)
                .WhereIf(endTime.HasValue, auditLog => auditLog.ExecutionTime <= endTime)
                .WhereIf(hasException.HasValue && hasException.Value, auditLog => auditLog.Exceptions != null && auditLog.Exceptions != "")
                .WhereIf(hasException.HasValue && !hasException.Value, auditLog => auditLog.Exceptions == null || auditLog.Exceptions == "")
                .WhereIf(httpMethod != null, auditLog => auditLog.HttpMethod == httpMethod)
                .WhereIf(url != null, auditLog => auditLog.Url != null && auditLog.Url.Contains(url))
                .WhereIf(userName != null, auditLog => auditLog.UserName == userName)
                .WhereIf(applicationName != null, auditLog => auditLog.ApplicationName == applicationName)
                .WhereIf(correlationId != null, auditLog => auditLog.CorrelationId == correlationId)
                .WhereIf(httpStatusCode != null && httpStatusCode > 0, auditLog => auditLog.HttpStatusCode == (int?)httpStatusCode)
                .WhereIf(maxDuration != null && maxDuration > 0, auditLog => auditLog.ExecutionDuration <= maxDuration)
                .WhereIf(minDuration != null && minDuration > 0, auditLog => auditLog.ExecutionDuration >= minDuration);
        }


        public virtual async Task<Dictionary<DateTime, double>> GetAverageExecutionDurationPerDayAsync(DateTime startDate, DateTime endDate)
        {
            var result = await GetMongoQueryable()
                .Where(a => a.ExecutionTime < endDate.AddDays(1) && a.ExecutionTime > startDate)
                .OrderBy(t => t.ExecutionTime)
                .GroupBy(t => new
                {
                    t.ExecutionTime.Year,
                    t.ExecutionTime.Month,
                    t.ExecutionTime.Day
                })
                .Select(g => new { Day = g.Min(t => t.ExecutionTime), avgExecutionTime = g.Average(t => t.ExecutionDuration) })
                .ToListAsync();

            return result.ToDictionary(element => element.Day.ClearTime(), element => element.avgExecutionTime);
        }

        public virtual async Task<EntityChange> GetEntityChange(Guid entityChangeId)
        {
            return (await GetMongoQueryable()
                            .Where(x => x.EntityChanges.Any(y => y.Id == entityChangeId))
                            .FirstAsync()
                    ).EntityChanges.First(x => x.Id == entityChangeId);
        }

        public virtual async Task<List<EntityChange>> GetEntityChangeListAsync(
            string sorting = null,
            int maxResultCount = 50,
            int skipCount = 0,
            Guid? auditLogId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            EntityChangeType? changeType = null,
            string entityId = null,
            string entityTypeFullName = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            var query = GetEntityChangeListQuery(auditLogId, startTime, endTime, changeType, entityId, entityTypeFullName);

            var auditLogs = await query.As<IMongoQueryable<AuditLog>>()
                .PageBy<AuditLog, IMongoQueryable<AuditLog>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
            
            // TODO: Improve this specification

            return auditLogs
                .SelectMany(x => x.EntityChanges.Where(y =>
                    IsSatisfiedEntityChange(y, auditLogId, startTime, endTime, changeType, entityId, entityTypeFullName)))
                .AsQueryable().OrderBy(sorting ?? "changeTime desc").ToList();
        }

        public virtual async Task<long> GetEntityChangeCountAsync(
            Guid? auditLogId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            EntityChangeType? changeType = null,
            string entityId = null,
            string entityTypeFullName = null,
            CancellationToken cancellationToken = default)
        {
            var query = GetEntityChangeListQuery(auditLogId, startTime, endTime, changeType, entityId, entityTypeFullName);
            var count = await query.As<IMongoQueryable<AuditLog>>()
                .LongCountAsync(GetCancellationToken(cancellationToken));

            return count;
        }

        public virtual async Task<EntityChangeWithUsername> GetEntityChangeWithUsernameAsync(Guid entityChangeId)
        {
            var auditLog = (await GetMongoQueryable()
                            .Where(x => x.EntityChanges.Any(y => y.Id == entityChangeId))
                            .FirstAsync());

            return new EntityChangeWithUsername()
            {
                EntityChange = auditLog.EntityChanges.First(x => x.Id == entityChangeId),
                UserName = auditLog.UserName
            };
        }

        public virtual async Task<List<EntityChangeWithUsername>> GetEntityChangesWithUsernameAsync(string entityId, string entityTypeFullName)
        {
            var auditLogs = await GetMongoQueryable()
                            .Where(x => x.EntityChanges.Any(y => y.EntityId == entityId && y.EntityTypeFullName == entityTypeFullName))
                            .As<IMongoQueryable<AuditLog>>()
                            .OrderByDescending(x => x.ExecutionTime)
                            .ToListAsync();

            var entityChanges = auditLogs.SelectMany(x => x.EntityChanges).ToList();
            
            entityChanges.RemoveAll(x => x.EntityId != entityId || x.EntityTypeFullName != entityTypeFullName);

            return entityChanges.Select(x => new EntityChangeWithUsername()
                {EntityChange = x, UserName = auditLogs.First(y => y.Id == x.AuditLogId).UserName}).ToList();
        }

        protected virtual IQueryable<AuditLog> GetEntityChangeListQuery(
            Guid? auditLogId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            EntityChangeType? changeType = null,
            string entityId = null,
            string entityTypeFullName = null)
        {
            return GetMongoQueryable()
                    .Where(x => x.EntityChanges != null)
                    .WhereIf(auditLogId.HasValue, e => e.Id == auditLogId)
                    .WhereIf(startTime.HasValue, e => e.EntityChanges.Any(ec => ec.ChangeTime >= startTime))
                    .WhereIf(endTime.HasValue, e => e.EntityChanges.Any(ec => ec.ChangeTime >= endTime))
                    .WhereIf(changeType.HasValue, e => e.EntityChanges.Any(ec => ec.ChangeType == changeType))
                    .WhereIf(!string.IsNullOrWhiteSpace(entityId), e => e.EntityChanges.Any(ec => ec.EntityId == entityId))
                    .WhereIf(!string.IsNullOrWhiteSpace(entityTypeFullName),
                        e => e.EntityChanges.Any(ec => ec.EntityTypeFullName.Contains(entityTypeFullName)));
        }

        protected virtual bool IsSatisfiedEntityChange(
            EntityChange entityChange, 
            Guid? auditLogId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            EntityChangeType? changeType = null,
            string entityId = null,
            string entityTypeFullName = null)
        {
            if (auditLogId != null && auditLogId != entityChange.AuditLogId)
            {
                return false;
            }

            if (startTime != null && startTime.Value >= entityChange.ChangeTime)
            {
                return false;
            }

            if (endTime != null && endTime.Value <= entityChange.ChangeTime)
            {
                return false;
            }

            if (changeType != null && changeType != entityChange.ChangeType)
            {
                return false;
            }

            if (entityId != null && entityId != entityChange.EntityId)
            {
                return false;
            }

            if (entityTypeFullName != null && entityChange.EntityTypeFullName.Contains(entityTypeFullName))
            {
                return false;
            }

            return true;
        }
    }
}
