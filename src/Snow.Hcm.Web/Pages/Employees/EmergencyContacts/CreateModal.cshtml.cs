using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snow.Hcm.EmployeeManagement.EmergencyContacts;
using Snow.Hcm.EmployeeManagement.EmergencyContacts.Dtos;
using Snow.Hcm.EmployeeManagement.Employees;
using Snow.Hcm.Web.ViewModel.Employees.EmergencyContacts;

namespace Snow.Hcm.Web.Pages.Employees.EmergencyContacts
{
    public class CreateModalModel : HcmPageModel
    {

        private readonly IEmergencyContactAppService _emergencyContactAppService;

        public CreateModalModel(IEmergencyContactAppService emergencyContactAppService)
        {
            _emergencyContactAppService = emergencyContactAppService;
        }

        [BindProperty] public EmergencyContactCreateViewModel EmergencyContact { get; set; }

        public void OnGet(Guid employeeId)
        {
            EmergencyContact = new EmergencyContactCreateViewModel()
            {
                EmployeeId = employeeId
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _emergencyContactAppService
                .CreateAsync(EmergencyContact.EmployeeId, ObjectMapper.Map<EmergencyContactCreateViewModel, EmergencyContactCreateDto>(EmergencyContact));
            return NoContent();
        }
    }
}
