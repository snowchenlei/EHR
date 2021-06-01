using System;

namespace Snow.Hcm.OrganizationUnitManagement
{
    public class OrganizationUnitCreateOrUpdateDto
    {
        public virtual Guid? ParentId { get; set; }

        public virtual string DisplayName { get; set; }
    }
}