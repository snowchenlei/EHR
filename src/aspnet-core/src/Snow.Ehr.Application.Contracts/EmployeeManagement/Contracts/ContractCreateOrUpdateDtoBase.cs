using System;

namespace Snow.Ehr.EmployeeManagement.Contracts
{
    public class ContractCreateOrUpdateDtoBase
    {
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}