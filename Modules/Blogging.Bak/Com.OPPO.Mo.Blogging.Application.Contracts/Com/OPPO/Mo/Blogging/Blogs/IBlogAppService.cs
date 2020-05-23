using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Com.OPPO.Mo.Blogging.Blogs.Dtos;

namespace Com.OPPO.Mo.Blogging.Blogs
{
    public interface IBlogAppService : IApplicationService
    {
        Task<ListResultDto<BlogDto>> GetListAsync();

        Task<BlogDto> GetByShortNameAsync(string shortName);

        Task<BlogDto> GetAsync(Guid id);
        
        Task<BlogDto> Create(CreateBlogDto input);

        Task<BlogDto> Update(Guid id, UpdateBlogDto input);

        Task Delete(Guid id);
    }
}
