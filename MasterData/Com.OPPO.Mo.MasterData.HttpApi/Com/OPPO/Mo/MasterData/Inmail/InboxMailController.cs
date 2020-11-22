using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Com.OPPO.Mo.MasterData.InboxMail;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Users;

namespace Com.OPPO.Mo.MasterData
{
    [RemoteService(Name = MasterDataRemoteServiceConsts.RemoteServiceName)]
    [Area("Inmail")]
    [ControllerName("InboxMail")]
    [Route("api/mo/data/inmail/inbox-mail")]
    public class InboxMailController : AbpController, IInboxMailAppService
    {
        protected IInboxMailAppService InboxMailAppService { get; }

        public InboxMailController(IInboxMailAppService inboxMailAppService)
        {
            InboxMailAppService = inboxMailAppService;
        }

        [HttpPost]
        [Route("set-mail-subject-by-mail-code")]
        public async Task<Result> SetMailSubjectByCode(string mailCode, string mailSubject)
        {
            return await InboxMailAppService.SetMailSubjectByCode(mailCode, mailSubject);
        }

        [HttpGet]
        [Route("by-sender-name")]
        public async Task<Result<List<string>>> GetMailCodeBySenderName(string senderName)
        {
            return await InboxMailAppService.GetMailCodeBySenderName(senderName);
        }
    }
}
