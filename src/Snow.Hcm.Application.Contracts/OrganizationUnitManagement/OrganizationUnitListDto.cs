using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.OrganizationUnitManagement
{
    public class OrganizationUnitListDto:EntityDto<Guid>
    {
        public string Code { get; set; }

        public string DisplayName { get; set; }

        public bool IsParent { get; set; } = true;
    }
}
