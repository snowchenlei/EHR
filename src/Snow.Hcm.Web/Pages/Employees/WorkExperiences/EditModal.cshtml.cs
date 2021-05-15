using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snow.Hcm.EmployeeManagement.WorkExperiences;
using Snow.Hcm.EmployeeManagement.WorkExperiences.Dtos;
using Snow.Hcm.Web.ViewModel.Employees.WorkExperiences;

namespace Snow.Hcm.Web.Pages.Employees.WorkExperiences
{
    public class EditModalModel : HcmPageModel
    {
        private readonly IWorkExperienceAppService _workExperienceAppService;

        public EditModalModel(IWorkExperienceAppService workExperienceAppService)
        {
            _workExperienceAppService = workExperienceAppService;
        }

        [BindProperty]
        public WorkExperienceUpdateViewModel WorkExperience { get; set; }
        
        public async Task OnGetAsync(Guid employeeId, Guid workExperienceId)
        {
            var dto = await _workExperienceAppService
                .GetEditorAsync(employeeId, workExperienceId);
            WorkExperience = ObjectMapper.Map<GetWorkExperienceForEditorOutput, WorkExperienceUpdateViewModel>(dto);
            WorkExperience.Id = workExperienceId;
            WorkExperience.EmployeeId = employeeId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<WorkExperienceUpdateViewModel, WorkExperienceUpdateDto>(WorkExperience);

            string[] times = WorkExperience.WorkTime
                .Split(new char[] { '~' }, StringSplitOptions.RemoveEmptyEntries);

            dto.StartTime = Convert.ToDateTime(times[0] + " 00:00:00");
            dto.EndTime = Convert.ToDateTime(times[1] + " 00:00:00");

            await _workExperienceAppService
                .UpdateAsync(WorkExperience.EmployeeId, WorkExperience.Id,
                    dto);
            return NoContent();
        }
    }
}
