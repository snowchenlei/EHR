using Microsoft.AspNetCore.Mvc;
using Snow.Hcm.OrganizationUnitManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.Controllers.OrganizationUnits
{
    /// <summary>
    /// 组织机构
    /// </summary>
    [Route("api/organization-unit")]
    public class OrganizationUnitController : HcmController, IOrganizationUnitAppServices
    {
        private readonly IOrganizationUnitAppServices _organizationUnitAppServices;

        public OrganizationUnitController(IOrganizationUnitAppServices organizationUnitAppServices)
        {
            _organizationUnitAppServices = organizationUnitAppServices;
        }

        [HttpGet]
        [HttpGet("{parentId}")]
        public Task<ListResultDto<OrganizationUnitListDto>> GetChildren(Guid? parentId)
        {
            return _organizationUnitAppServices.GetChildren(parentId);
        }
    }
}
