using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Inmail.InboxMail
{
    [Authorize(InmailPermissions.InboxMail.Default)]
    public class InboxMailAppService : InmailAppServiceBase, IInboxMailAppService
    {
        private readonly IInboxMailDapperRepository _inboxMailDapperRepository;
        private readonly IInboxMailReadonlyDapperRepository _inboxMailReadonlyDapperRepository;

        public InboxMailAppService(IInboxMailDapperRepository inboxMailDapperRepository, IInboxMailReadonlyDapperRepository inboxMailReadonlyDapperRepository)
        {
            _inboxMailDapperRepository = inboxMailDapperRepository;
            _inboxMailReadonlyDapperRepository = inboxMailReadonlyDapperRepository;
        }

        public async Task<Result<List<string>>> GetMailCodeBySenderName(string senderName)
        {
            var mailCodes = await _inboxMailReadonlyDapperRepository.GetMailCodeBySenderName(senderName);
            return Result.FromData(mailCodes);
        }

        [Authorize(InmailPermissions.InboxMail.Update)]
        public async Task<Result> SetMailSubjectByCode(string mailCode, string mailSubject)
        {
            var affectedRowCount = await _inboxMailDapperRepository.SetMailSubjectByCode(mailCode, mailSubject);

            return Result.FromCode(affectedRowCount > 0 ? ResultCode.Ok : ResultCode.Fail);
        }
    }
}
