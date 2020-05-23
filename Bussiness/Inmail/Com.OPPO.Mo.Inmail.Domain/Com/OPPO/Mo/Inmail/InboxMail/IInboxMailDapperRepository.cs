using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Inmail.InboxMail
{
    public interface IInboxMailDapperRepository
    {
        Task<int> SetMailSubjectByCode(string mailCode, string mailSubject);
    }
}
