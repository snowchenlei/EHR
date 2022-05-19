using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Snow.Ehr.EmployeeManagement.Employees
{
    /// <summary>
    /// 生育状况
    /// </summary>
    public enum ReproductiveStatus
    {
        /// <summary>
        /// 未育
        /// </summary>
        [Description("未育")]
        Childless,

        /// <summary>
        /// 已育
        /// </summary>
        [Description("已育")]
        Procreated
    }
}
