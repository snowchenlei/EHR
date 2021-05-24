using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snow.Hcm.EmployeeManagement.EducationExperiences;
using Snow.Hcm.EmployeeManagement.EducationExperiences.Dtos;
using Snow.Hcm.Web.ViewModel.Employees.EducationExperiences;

namespace Snow.Hcm.Web.Pages.Employees.EducationExperiences
{
    public class CreateModalModel : HcmPageModel
    {
        private readonly IEducationExperienceAppService _educationExperienceAppService;

        public CreateModalModel(IEducationExperienceAppService educationExperienceAppService)
        {
            _educationExperienceAppService = educationExperienceAppService;
        }

        [BindProperty]
        public EducationExperienceCreateViewModel EducationExperience { get; set; }

        public void OnGet(Guid employeeId)
        {
            EducationExperience = new EducationExperienceCreateViewModel()
            {
                EmployeeId = employeeId
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<EducationExperienceCreateViewModel, EducationExperienceCreateDto>(EducationExperience);

            string[] times = EducationExperience.EducationTime
                .Split(new char[] { '~' }, StringSplitOptions.RemoveEmptyEntries);
            dto.StartTime = Convert.ToDateTime(times[0] + " 00:00:00");
            dto.EndTime = Convert.ToDateTime(times[1] + " 00:00:00");
            await _educationExperienceAppService.CreateAsync(EducationExperience.EmployeeId,
                dto);

            return NoContent();
        }
    }
}
