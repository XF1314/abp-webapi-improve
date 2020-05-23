using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Com.OPPO.Mo.Inmail.InboxMail;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Users;

namespace Com.OPPO.Mo.Inmail
{
    [RemoteService(Name = InmailRemoteServiceConsts.RemoteServiceName)]
    [Area("Inmail")]
    [ControllerName("InboxMail")]
    [Route("api/inmail/inbox-mail")]
    public class InboxMailController : AbpController, IInboxMailAppService
    {
        protected IInboxMailAppService InboxMailAppService { get; }

        public InboxMailController(IInboxMailAppService inboxMailAppService)
        {
            InboxMailAppService = inboxMailAppService;
        }

        [HttpPost]
        [Route("set-mailsubject-by-mailcode/{mailCode}")]
        public async Task<Result> SetMailSubjectByCode(string mailCode, string mailSubject)
        {
            return await InboxMailAppService.SetMailSubjectByCode(mailCode, mailSubject);
        }

        [HttpGet]
        [Route("by-sendername/{senderName}")]
        public async Task<Result<List<string>>> GetMailCodeBySenderName(string senderName)
        {
            return await InboxMailAppService.GetMailCodeBySenderName(senderName);
        }
    }
}
