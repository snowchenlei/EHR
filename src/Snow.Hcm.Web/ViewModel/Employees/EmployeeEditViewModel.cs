using Microsoft.AspNetCore.Mvc;
using Snow.Hcm.EmployeeManagement.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Snow.Hcm.Web.ViewModel.Employees
{
    public class EmployeeEditViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Placeholder("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Placeholder("PhoneNumber")]
        [RegularExpression("^1([358][0-9]|4[579]|66|7[0135678]|9[89])[0-9]{8}$")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [DisabledInput]
        public string IdCardNumber { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [Placeholder("Address")]
        public string Address { get; set; }

        /// <summary>
        /// 是否公历
        /// </summary>
        [Display(Name = "GregorianCalendar")]
        public bool IsGregorianCalendar { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 历法
        /// </summary>
        public Calendar Calendar { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        [DataType(DataType.CreditCard)]
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
        /// 部门
        /// </summary>
        [Display(Name = "Department")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [HiddenInput]
        public int ProvinceId { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [HiddenInput]
        public int CityId { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        [HiddenInput]
        public int AreaId { get; set; }
    }
}
