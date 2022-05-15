using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Ehr.EmployeeManagement.EmergencyContacts
{
    /// <summary>
    /// 列表
    /// </summary>
    public class EmergencyContactDetailDto: EntityDto<int>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Relation { get; set; }
    }
}