using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Snow.Hcm.OrganizationUnitManagement
{
    public interface IOrganizationUnitAppServices:IApplicationService
    {
        Task<ListResultDto<OrganizationUnitListDto>> GetChildren(Guid? parentId);
    }
}