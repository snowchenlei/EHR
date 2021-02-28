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
        /// 男性
        /// </summary>
        [Description("男性")]
        Man,

        /// <summary>
        /// 女性
        /// </summary>
        [Description("女性")]
        Woman
    }
}
