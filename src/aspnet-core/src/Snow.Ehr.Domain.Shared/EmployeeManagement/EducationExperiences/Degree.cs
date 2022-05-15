using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Ehr.EmployeeManagement.EducationExperiences
{
    public enum Degree
    {
        /// <summary>
        /// 博士
        /// </summary>
        Doctorate,

        /// <summary>
        /// MBA/EMBA
        /// </summary>
        MBA,
        
        /// <summary>
        /// 硕士
        /// </summary>
        Master,

        /// <summary>
        /// 本科
        /// </summary>
        Undergraduate,
        
        /// <summary>
        /// 大专
        /// </summary>
        JuniorCollegeStudent,

        /// <summary>
        /// 中专
        /// </summary>
        TechnicalSecondarySchool,

        /// <summary>
        /// 高中学历
        /// </summary>
        HigherSchoolEducation,

        /// <summary>
        /// 初中学历
        /// </summary>
        JuniorHighSchoolEducation,

        /// <summary>
        /// 小学学历
        /// </summary>
        PrimarySchoolEducation
    }
}
