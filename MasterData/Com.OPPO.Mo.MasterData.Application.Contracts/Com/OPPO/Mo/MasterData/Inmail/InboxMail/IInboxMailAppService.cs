using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.MasterData.InboxMail
{
    public interface IInboxMailAppService : IApplicationService
    {
        Task<Result> SetMailSubjectByCode(string mailCode, string mailSubject);

        Task<Result<List<string>>> GetMailCodeBySenderName(string senderName);
    }
}

