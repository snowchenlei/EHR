using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Hcm.EmployeeManagement.Employees
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        UnKnown,

        /// <summary>
        /// 男
        /// </summary>
        [Description("男")]
        Man,

        /// <summary>
        /// 女
        /// </summary>
        [Description("女")]
        Woman
    }
}
