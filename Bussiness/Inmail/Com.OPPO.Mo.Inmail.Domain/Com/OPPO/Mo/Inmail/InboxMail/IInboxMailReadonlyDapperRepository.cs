using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Inmail.InboxMail
{
    public interface IInboxMailReadonlyDapperRepository
    {
        Task<List<string>> GetMailCodeBySenderName(string senderName);
    }
}
