using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Snow.Hcm.Web.ViewModel.Employees.WorkExperiences
{
    public class WorkExperienceCreateViewModel
    {
        /// <summary>
        /// 公司名称
        /// </summary>
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
        public string WorkTime { get; set; }
        
        /// <summary>
        /// 员工Id
        /// </summary>
        public Guid EmployeeId { get; set; }
    }
}
