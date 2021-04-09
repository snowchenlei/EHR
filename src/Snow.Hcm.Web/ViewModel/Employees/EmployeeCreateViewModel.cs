﻿using Snow.Hcm.EmployeeManagement.Employees;
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
        /// 年龄
        /// </summary>
        [Placeholder("Age")]
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Placeholder("PhoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Placeholder("IdCardNumber")]
        public string IdCardNumber { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [Placeholder("Address")]
        public string Address { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDay { get; set; }

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
