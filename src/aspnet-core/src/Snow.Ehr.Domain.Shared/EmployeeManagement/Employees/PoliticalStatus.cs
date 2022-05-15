using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Ehr.EmployeeManagement.Employees
{
    /// <summary>
    /// 政治面貌
    /// </summary>
    public enum PoliticalStatus
    {
        /// <summary>
        /// 群众
        /// </summary>
        [Description("群众")]
        PublicPeople,

        /// <summary>
        /// 党员
        /// </summary>
        [Description("党员")]
        CPC,

        /// <summary>
        /// 团员
        /// </summary>
        [Description("团员")]
        LeagueMember,

        /// <summary>
        /// 无党派人士
        /// </summary>
        [Description("无党派人士")]
        Non,
    }
}
