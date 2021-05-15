using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Masuit.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snow.Hcm.EmployeeManagement.WorkExperiences;
using Snow.Hcm.EmployeeManagement.WorkExperiences.Dtos;
using Snow.Hcm.Web.ViewModel.Employees.WorkExperiences;

namespace Snow.Hcm.Web.Pages.Employees.WorkExperiences
{
    public class CreateModalModel : HcmPageModel
    {
        private readonly IWorkExperienceAppService _workExperienceAppService;

        public CreateModalModel(IWorkExperienceAppService workExperienceAppService)
        {
            _workExperienceAppService = workExperienceAppService;
        }

        [BindProperty] public WorkExperienceCreateViewModel WorkExperience { get; set; }
        public void OnGet(Guid employeeId)
        {
            WorkExperience = new WorkExperienceCreateViewModel()
            {
                EmployeeId = employeeId
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<WorkExperienceCreateViewModel, WorkExperienceCreateDto>(WorkExperience);

            string[] times = WorkExperience.WorkTime
                .Split(new char[] {'~'}, StringSplitOptions.RemoveEmptyEntries);
            dto.StartTime = Convert.ToDateTime(times[0] + " 00:00:00");
            dto.EndTime = Convert.ToDateTime(times[1] + " 00:00:00");
            await _workExperienceAppService.CreateAsync(WorkExperience.EmployeeId,
                dto);
            
            return NoContent();
        }
    }
}
