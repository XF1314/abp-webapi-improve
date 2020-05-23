namespace Com.OPPO.Mo.Account.Web.Areas.Account.Controllers.Models
{
    public class MoLoginResult
    {
        public MoLoginResult(LoginResultType result)
        {
            Result = result;
        }

        public LoginResultType Result { get; }

        public string Description => Result.ToString();
    }
}