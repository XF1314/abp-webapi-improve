﻿using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Com.OPPO.Mo.AuditLogging
{
    [DisableAuditing]
    public class AuditLog : AggregateRoot<Guid>, IMultiTenant
    {
        public virtual string ApplicationName { get; set; }

        public virtual Guid? UserId { get; protected set; }

        public virtual string UserName { get; protected set; }

        public virtual Guid? TenantId { get; protected set; }

        public virtual string TenantName { get; protected set; }

        public virtual Guid? ImpersonatorUserId { get; protected set; }

        public virtual Guid? ImpersonatorTenantId { get; protected set; }

        public virtual DateTime ExecutionTime { get; protected set; }

        public virtual int ExecutionDuration { get; protected set; }

        public virtual string ClientIpAddress { get; protected set; }

        public virtual string ClientName { get; protected set; }

        public virtual string ClientId { get; set; }

        public virtual string CorrelationId { get; set; }

        public virtual string BrowserInfo { get; protected set; }

        public virtual string HttpMethod { get; protected set; }

        public virtual string Url { get; protected set; }

        public virtual string Exceptions { get; protected set; }

        public virtual string Comments { get; protected set; }

        public virtual int? HttpStatusCode { get; set; }

        public virtual ICollection<EntityChange> EntityChanges { get; protected set; }

        public virtual ICollection<AuditLogAction> Actions { get; protected set; }

        protected AuditLog()
        {
            ExtraProperties = new Dictionary<string, object>();
        }

        public AuditLog(IGuidGenerator guidGenerator, AuditLogInfo auditInfo)
        {
            Id = guidGenerator.Create();
            ApplicationName = auditInfo.ApplicationName.Truncate(AuditLogConsts.MaxApplicationNameLength);
            TenantId = auditInfo.TenantId;
            TenantName = auditInfo.TenantName.Truncate(AuditLogConsts.MaxTenantNameLength);
            UserId = auditInfo.UserId;
            UserName = auditInfo.UserName.Truncate(AuditLogConsts.MaxUserNameLength);
            ExecutionTime = auditInfo.ExecutionTime;
            ExecutionDuration = auditInfo.ExecutionDuration;
            ClientIpAddress = auditInfo.ClientIpAddress.Truncate(AuditLogConsts.MaxClientIpAddressLength);
            ClientName = auditInfo.ClientName.Truncate(AuditLogConsts.MaxClientNameLength);
            ClientId = auditInfo.ClientId.Truncate(AuditLogConsts.MaxClientIdLength);
            CorrelationId = auditInfo.CorrelationId.Truncate(AuditLogConsts.MaxCorrelationIdLength);
            BrowserInfo = auditInfo.BrowserInfo.Truncate(AuditLogConsts.MaxBrowserInfoLength);
            HttpMethod = auditInfo.HttpMethod.Truncate(AuditLogConsts.MaxHttpMethodLength);
            Url = auditInfo.Url.Truncate(AuditLogConsts.MaxUrlLength);
            HttpStatusCode = auditInfo.HttpStatusCode;
            ImpersonatorUserId = auditInfo.ImpersonatorUserId;
            ImpersonatorTenantId = auditInfo.ImpersonatorTenantId;

            ExtraProperties = auditInfo
                                  .ExtraProperties?
                                  .ToDictionary(pair => pair.Key, pair => pair.Value)
                              ?? new Dictionary<string, object>();

            EntityChanges = auditInfo
                                .EntityChanges?
                                .Select(entityChangeInfo => new EntityChange(guidGenerator, Id, entityChangeInfo, tenantId: auditInfo.TenantId))
                                .ToList()
                            ?? new List<EntityChange>();

            Actions = auditInfo
                          .Actions?
                          .Select(auditLogActionInfo => new AuditLogAction(guidGenerator.Create(), Id, auditLogActionInfo, tenantId: auditInfo.TenantId))
                          .ToList()
                      ?? new List<AuditLogAction>();

            Exceptions = auditInfo
                .Exceptions?
                .JoinAsString(Environment.NewLine)
                .Truncate(AuditLogConsts.MaxExceptionsLength);

            Comments = auditInfo
                .Comments?
                .JoinAsString(Environment.NewLine)
                .Truncate(AuditLogConsts.MaxCommentsLength);
        }
    }
}
