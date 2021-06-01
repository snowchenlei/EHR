using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Snow.Hcm.OrganizationUnitManagement
{
    public class OrganizationUnitManagementAppServices : HcmAppService, IOrganizationUnitManagementAppServices
    {
        private readonly OrganizationUnitManager _organizationUnitManager;
        private readonly IOrganizationUnitRepository _organizationUnitRepository;

        public OrganizationUnitManagementAppServices(OrganizationUnitManager organizationUnitManager, IOrganizationUnitRepository organizationUnitRepository)
        {
            _organizationUnitManager = organizationUnitManager;
            _organizationUnitRepository = organizationUnitRepository;
        }

        public virtual async Task<ListResultDto<OrganizationUnitListDto>> GetChildren(Guid? parentId)
        {
            List<OrganizationUnit> organizationUnits = await _organizationUnitManager.FindChildrenAsync(parentId);
            // TODO:IsParentCheck
            return new ListResultDto<OrganizationUnitListDto>(
                ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitListDto>>(organizationUnits));
        }

        public virtual async Task<OrganizationUnitListDto> CreateAsync(OrganizationUnitCreateDto input)
        {
            var entity = ObjectMapper.Map<OrganizationUnitCreateDto, OrganizationUnit>(input);
            await _organizationUnitManager.CreateAsync(entity);
            return ObjectMapper.Map<OrganizationUnit, OrganizationUnitListDto>(entity);
        }

        public virtual async Task UpdateAsync(Guid id, OrganizationUnitUpdateDto input)
        {
            var entity = await _organizationUnitRepository.GetAsync(id);
            entity = ObjectMapper.Map(input, entity);
            await _organizationUnitManager.UpdateAsync(entity);
        }

        public virtual async Task MoveAsync(Guid id, Guid? parentId)
        {
            await _organizationUnitManager.MoveAsync(id, parentId);
        }

        //public virtual async Task SetRole(Guid roleId, List<Guid> ouIds)
        //{
        //    //await _organizationUnitManager.AddRoleToOrganizationUnitAsync(roleId, ouId);
        //}
        
        public virtual async Task DeleteAsync(Guid id)
        {
            await _organizationUnitManager.DeleteAsync(id);
        }
}
}
