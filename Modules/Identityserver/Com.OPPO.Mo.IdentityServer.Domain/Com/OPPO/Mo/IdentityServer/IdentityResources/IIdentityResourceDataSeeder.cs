using System.Threading.Tasks;

namespace Com.OPPO.Mo.IdentityServer.IdentityResources
{
    public interface IIdentityResourceDataSeeder
    {
        Task CreateStandardResourcesAsync();
    }
}