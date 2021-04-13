using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Snow.Hcm.Web.ViewModel.Employees
{
    /// <summary>
    /// 历法
    /// </summary>
    public enum Calendar
    {
        /// <summary>
        /// 公历
        /// </summary>
        [Description("公历")]
        GregorianCalendar,

        /// <summary>
        /// 农历
        /// </summary>
        [Description("农历")]
        ChineseCalendar
    }
}
