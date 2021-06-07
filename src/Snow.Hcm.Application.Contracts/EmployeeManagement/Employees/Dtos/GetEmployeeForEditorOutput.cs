using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.EmployeeManagement.Employees.Dtos
{
    /// <summary>
    /// 修改输出
    /// </summary>
    public class GetEmployeeForEditorOutput :EntityDto<Guid>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNumber { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankCardNumber { get; set; }

        /// <summary>
        /// 婚姻状态
        /// </summary>
        public MaritalStatus MaritalStatus { get; set; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        public PoliticalStatus PoliticalStatus { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 是否公历
        /// </summary>
        public bool IsGregorianCalendar { get; set; }

        /// <summary>
        /// 头像Id
        /// </summary>
        public Guid? CoverImageMediaId { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public int ProvinceId { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        public int AreaId { get; set; }
    }
}