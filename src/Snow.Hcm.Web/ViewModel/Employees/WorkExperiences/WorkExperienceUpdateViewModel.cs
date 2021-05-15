using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Snow.Hcm.Web.ViewModel.Employees.WorkExperiences
{
    public class WorkExperienceUpdateViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [HiddenInput]
        public Guid Id { get; set; }

        /// <summary>
        /// 员工Id
        /// </summary>
        [HiddenInput]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [Required]
        public string CompanyName { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [TextArea(Rows = 4)]
        public string Description { get; set; }

        /// <summary>
        /// 工作时间
        /// </summary>
        [Required]
        public string WorkTime { get; set; }
    }
}
