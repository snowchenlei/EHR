using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Snow.Ehr.EmployeeManagement.Employees
{
    /// <summary>
    /// 星座
    /// </summary>
    public enum Constellation
    {
        /// <summary>
        /// 魔羯座(12/22-01/19)
        /// </summary>
        [Description("魔羯座")]
        Capricorn,

        /// <summary>
        /// 水瓶座(01/20-02/18)
        /// </summary>
        [Description("水瓶座")]
        Aquarius,

        /// <summary>
        /// 双鱼座(02/19-03/20)
        /// </summary>
        [Description("双鱼座")]
        Pisces,

        /// <summary>
        /// 白羊座(03/21-04/20)
        /// </summary>
        [Description("白羊座")]
        Aries,

        /// <summary>
        /// 金牛座(04/21-05/20)
        /// </summary>
        [Description("金牛座")]
        Taurus,

        /// <summary>
        /// 双子座(05/21-6/21)
        /// </summary>
        [Description("双子座")]
        Gemini,

        /// <summary>
        /// 巨蟹座(06/22-07/22)
        /// </summary>
        [Description("巨蟹座")]
        Cancer,

        /// <summary>
        /// 狮子座(07/23-08/22)
        /// </summary>
        [Description("狮子座")]
        Leo,

        /// <summary>
        /// 处女座(08/23-09/22)
        /// </summary>
        [Description("处女座")]
        Virgo,

        /// <summary>
        /// 天秤座(09/23-10/23)
        /// </summary>
        [Description("天秤座")]
        Libra,

        /// <summary>
        /// 天蝎座(10/24-11/21)
        /// </summary>
        [Description("天蝎座")]
        Scorpio,

        /// <summary>
        /// 射手座(11/22-12/21)
        /// </summary>
        [Description("射手座")]
        Sagittarius
    }
}
