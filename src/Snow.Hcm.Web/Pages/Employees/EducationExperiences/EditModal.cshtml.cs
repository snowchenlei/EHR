using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snow.Hcm.EmployeeManagement.EducationExperiences;
using Snow.Hcm.EmployeeManagement.EducationExperiences.Dtos;
using Snow.Hcm.Web.ViewModel.Employees.EducationExperiences;
using Volo.Abp.ObjectMapping;

namespace Snow.Hcm.Web.Pages.Employees.EducationExperiences
{
    public class EditModalModel : HcmPageModel
    {
        private readonly IEducationExperienceAppService _educationExperienceAppService;

        public EditModalModel(IEducationExperienceAppService educationExperienceAppService)
        {
            _educationExperienceAppService = educationExperienceAppService;
        }

        [BindProperty]
        public EducationExperienceUpdateViewModel EducationExperience { get; set; }

        public async Task OnGetAsync(Guid employeeId, Guid educationExperienceId)
        {
            var dto = await _educationExperienceAppService.GetEditorAsync(employeeId, educationExperienceId);
            EducationExperience = ObjectMapper.Map<GetEducationExperienceForEditorOutput, EducationExperienceUpdateViewModel>(dto);            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<EducationExperienceUpdateViewModel, EducationExperienceUpdateDto>(EducationExperience);

            string[] times = EducationExperience.EducationTime
                .Split(new char[] { '~' }, StringSplitOptions.RemoveEmptyEntries);

            dto.StartTime = Convert.ToDateTime(times[0] + " 00:00:00");
            dto.EndTime = Convert.ToDateTime(times[1] + " 00:00:00");

            await _educationExperienceAppService
                .UpdateAsync(EducationExperience.EmployeeId, EducationExperience.Id,
                    dto);
            return NoContent();
        }
    }
}
