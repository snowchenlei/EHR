using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snow.Hcm.OrganizationUnitManagement;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.Controllers.OrganizationUnitManagement
{
    /// <summary>
    /// 组织机构
    /// </summary>
    [Route("api/organization-unit-management")]
    public class OrganizationUnitController : HcmController, IOrganizationUnitManagementAppServices
    {
        private readonly IOrganizationUnitManagementAppServices _organizationUnitAppServices;

        public OrganizationUnitController(IOrganizationUnitManagementAppServices organizationUnitAppServices)
        {
            _organizationUnitAppServices = organizationUnitAppServices;
        }

        [HttpGet]
        [HttpGet("{parentId}")]
        public Task<ListResultDto<OrganizationUnitListDto>> GetChildren(Guid? parentId)
        {
            return _organizationUnitAppServices.GetChildren(parentId);
        }

        [HttpPost]
        public async Task<OrganizationUnitListDto> CreateAsync(OrganizationUnitCreateDto input)
        {
            return await _organizationUnitAppServices.CreateAsync(input);
        }

        [HttpPut("{id}")]
        public async Task UpdateAsync(Guid id, OrganizationUnitUpdateDto input)
        {
            await _organizationUnitAppServices.UpdateAsync(id, input);
        }

        //[HttpPatch("{id}/to/")]
        //public async Task MoveAsync(Guid id)
        //{
        //    await _organizationUnitAppServices.MoveAsync(id, null);
        //}

        [HttpPatch("{id}/to")]
        public async Task MoveAsync(Guid id, Guid? parentId)
        {
            await _organizationUnitAppServices.MoveAsync(id, parentId);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _organizationUnitAppServices.DeleteAsync(id);
        }
    }
}
