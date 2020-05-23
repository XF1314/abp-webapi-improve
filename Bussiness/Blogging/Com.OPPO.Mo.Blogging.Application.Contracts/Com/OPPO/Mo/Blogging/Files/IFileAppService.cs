using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Blogging.Files
{
    public interface IFileAppService : IApplicationService
    {
        Task<RawFileDto> GetAsync(string name);

        Task<FileUploadOutputDto> CreateAsync(FileUploadInputDto input);
    }
}
