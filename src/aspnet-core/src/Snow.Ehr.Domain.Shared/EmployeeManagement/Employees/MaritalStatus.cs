using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Ehr.EmployeeManagement.Employees
{
    /// <summary>
    /// 婚姻状态
    /// </summary>
    public enum MaritalStatus
    {
        /// <summary>
        /// 未婚
        /// </summary>
        [Description("未婚")]
        Unmarried,

        /// <summary>
        /// 已婚
        /// </summary>
        [Description("已婚")]
        Married,

        /// <summary>
        /// 离异
        /// </summary>
        [Description("离异")]
        Divorced,

        /// <summary>
        /// 丧偶
        /// </summary>
        [Description("丧偶")]
        Widowed
    }
}
