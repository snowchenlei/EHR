using System;
using System.Collections.Generic;
using System.Text;

namespace Snow.Hcm.Extension
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 根据生日获取年龄
        /// </summary>
        /// <param name="birthday">生日</param>
        /// <returns></returns>
        public static int GetAgeByBirthday(this DateTime birthday)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthday.Year;
            if (now.Month < birthday.Month || (now.Month == birthday.Month && now.Day < birthday.Day))
            {
                age--;
            }
            return age < 0 ? 0 : age;
        }
    }
}
