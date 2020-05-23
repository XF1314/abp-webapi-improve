namespace Com.OPPO.Mo.Account.Web
{
    public class MoAccountOptions
    {
        /// <summary>
        /// Default value: "Windows".
        /// </summary>
        public string WindowsAuthenticationSchemeName { get; set; }

        public MoAccountOptions()
        {
            //TODO: This makes us depend on the Microsoft.AspNetCore.Server.IISIntegration package.
            WindowsAuthenticationSchemeName = "Windows"; //Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme;
        }
    }
}
