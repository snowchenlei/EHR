using Snow.Hcm.EmployeeManagement.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Snow.Hcm.Web.ViewModel.Employees
{
    public class EmployeeCreateViewModel
    {
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
        [Placeholder("IdCardNumber")]
        [RegularExpression("(^[1-9]\\d{5}(18|19|([23]\\d))\\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\\d{3}[0-9Xx]$)|(^[1-9]\\d{5}\\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\\d{2}$)")]
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
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// 历法
        /// </summary>
        public Calendar Calendar { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [Display(Name = "Department")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// 所在区域
        /// </summary>
        [HiddenInput]
        public int AreaId { get; set; }
    }
}
