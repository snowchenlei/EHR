using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Snow.Hcm.OrganizationUnitManagement
{
    public interface IOrganizationUnitManagementAppServices:IApplicationService
    {
        Task<ListResultDto<OrganizationUnitListDto>> GetChildren(Guid? parentId);

        Task<OrganizationUnitListDto> CreateAsync(OrganizationUnitCreateDto input);

        Task UpdateAsync(Guid id, OrganizationUnitUpdateDto input);

        Task MoveAsync(Guid id, Guid? parentId);
        Task DeleteAsync(Guid id);
    }
}