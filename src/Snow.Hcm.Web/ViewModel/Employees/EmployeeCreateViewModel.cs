using Snow.Hcm.EmployeeManagement.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Snow.Hcm.Web.ViewModel.Employees
{
    public class EmployeeCreateViewModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

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
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// 所在区域
        /// </summary>
        [HiddenInput]
        public int AreaId { get; set; }
    }
}
