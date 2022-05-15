using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Snow.Ehr.EmployeeManagement.Employees
{
    /// <summary>
    /// 在职状态
    /// </summary>
    public enum InServiceStatus
    {
        /// <summary>
        /// 在职
        /// </summary>
        [Description("在职")]
        In,

        /// <summary>
        /// 离职
        /// </summary>
        [Description("离职")]
        Out
    }
}
