using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.EmployeeManagement.EmergencyContacts.Dtos
{
    /// <summary>
    /// 列表
    /// </summary>
    public class EmergencyContactListDto: EntityDto<Guid>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Relation { get; set; }
    }
}