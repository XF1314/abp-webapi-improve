using Com.OPPO.Mo.Bpm.Localization;
using Com.OPPO.Mo.Bpm.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using Volo.Abp.Security.Claims;

namespace Com.OPPO.Mo.Bpm
{
    public class BpmAppServiceBase : ApplicationService
    {
        private IConfiguration _configuration;
        private ICurrentPrincipalAccessor _currentPrincipalAccessor;
        private IEaiTaskInstanceBelongRepository _EaiTaskBelongRepository;
        private IBusinessObjectBelongRepository _businessObjectBelongRepository;
        private IProcessInstanceBelongRepository _processInstanceBelongRepository;
        private IProcessLaunchPermissionRepository _processLaunchPermissionRepository;
        private IBusinessObjectTablePermissionRepository _businessObjectTablePermissionRepository;

        public IConfiguration Configuration => LazyGetRequiredService(ref _configuration);
        public ICurrentPrincipalAccessor CurrentPrincipalAccessor => LazyGetRequiredService(ref _currentPrincipalAccessor);
        public IEaiTaskInstanceBelongRepository EaiTaskBelongRepository => LazyGetRequiredService(ref _EaiTaskBelongRepository);
        public IBusinessObjectBelongRepository BusinessObjectBelongRepository => LazyGetRequiredService(ref _businessObjectBelongRepository);
        public IProcessInstanceBelongRepository ProcessInstanceBelongRepository => LazyGetRequiredService(ref _processInstanceBelongRepository);
        public IProcessLaunchPermissionRepository ProcessLaunchPermissionRepository => LazyGetRequiredService(ref _processLaunchPermissionRepository);
        public IBusinessObjectTablePermissionRepository BusinessObjectTablePermissionRepository => LazyGetRequiredService(ref _businessObjectTablePermissionRepository);

        protected BpmAppServiceBase()
        {
            ObjectMapperContext = typeof(MoBpmApplicationModule);
            LocalizationResource = typeof(MoBpmResource);
        }
    }
}