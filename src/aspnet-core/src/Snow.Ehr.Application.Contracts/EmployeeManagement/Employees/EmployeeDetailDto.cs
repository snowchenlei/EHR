﻿using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Ehr.EmployeeManagement.Employees
{
    /// <summary>
    /// 列表
    /// </summary>
    public class EmployeeDetailDto: EntityDto<System.Guid>
    {
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string IdCardNumber { get; set; }
        public string Address { get; set; }
        public System.DateTime BirthDay { get; set; }
        public System.DateTime JoinDate { get; set; }
        public System.DateTime ConfirmationDate { get; set; }
    }
}