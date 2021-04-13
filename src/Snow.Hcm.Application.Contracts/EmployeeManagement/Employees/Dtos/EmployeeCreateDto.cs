namespace Snow.Hcm.EmployeeManagement.Employees.Dtos
{
    /// <summary>
    /// 创建
    /// </summary>
    public class EmployeeCreateDto : EmployeeCreateOrUpdateDtoBase
    {

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNumber { get; set; }
    }
}