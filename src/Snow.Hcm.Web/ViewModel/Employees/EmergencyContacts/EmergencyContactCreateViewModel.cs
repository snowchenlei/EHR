using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snow.Hcm.Web.ViewModel.Employees.EmergencyContacts
{
    public class EmergencyContactCreateViewModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 关系
        /// </summary>
        public string Relation { get; set; }

        /// <summary>
        /// 员工Id
        /// </summary>
        [HiddenInput]
        public Guid EmployeeId { get; set; }
    }
}
