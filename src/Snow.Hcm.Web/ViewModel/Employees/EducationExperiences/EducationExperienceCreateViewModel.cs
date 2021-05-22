using Microsoft.AspNetCore.Mvc;
using Snow.Hcm.EmployeeManagement.EducationExperiences;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Snow.Hcm.Web.ViewModel.Employees.EducationExperiences
{
    public class EducationExperienceCreateViewModel
    {
        /// <summary>
        /// 学校名称
        /// </summary>
        [Required]
        public string SchoolName { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        public string Specialty { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public Degree Degree { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [TextArea(Rows = 4)]
        public string Description { get; set; }

        /// <summary>
        /// 教育时间
        /// </summary>
        [Required]
        public string EducationTime { get; set; }

        /// <summary>
        /// 员工Id
        /// </summary>
        [HiddenInput]
        public Guid EmployeeId { get; set; }
    }
}
