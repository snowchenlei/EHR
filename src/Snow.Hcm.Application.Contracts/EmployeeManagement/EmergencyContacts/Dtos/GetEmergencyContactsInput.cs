using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.EmployeeManagement.EmergencyContacts.Dtos
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public class GetEmergencyContactsInput: PagedAndSortedResultRequestDto
    {
        public Guid EmployeeId { get; set; }
    }
}