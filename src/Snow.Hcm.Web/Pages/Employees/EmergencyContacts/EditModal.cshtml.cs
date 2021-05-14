using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snow.Hcm.EmployeeManagement.EmergencyContacts;
using Snow.Hcm.EmployeeManagement.EmergencyContacts.Dtos;
using Snow.Hcm.Web.ViewModel.Employees.EmergencyContacts;

namespace Snow.Hcm.Web.Pages.Employees.EmergencyContacts
{
    public class EditModalModel : HcmPageModel
    {
        private readonly IEmergencyContactAppService _emergencyContactAppService;

        public EditModalModel([NotNull] IEmergencyContactAppService emergencyContactAppService)
        {
            _emergencyContactAppService = emergencyContactAppService ?? throw new ArgumentNullException(nameof(emergencyContactAppService));
        }

        [BindProperty]
        public EmergencyContactEditViewModel EmergencyContact { get; set; }
        
        public async Task OnGetAsync(Guid employeeId, Guid emergencyContactId)
        {
            var dto = await _emergencyContactAppService.GetEditorAsync(employeeId, emergencyContactId);
            EmergencyContact = ObjectMapper.Map<GetEmergencyContactForEditorOutput, EmergencyContactEditViewModel>(dto);
            EmergencyContact.EmployeeId = employeeId;
            EmergencyContact.Id = emergencyContactId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<EmergencyContactEditViewModel, EmergencyContactUpdateDto>(EmergencyContact);
            await _emergencyContactAppService.UpdateAsync(EmergencyContact.EmployeeId, EmergencyContact.Id, dto);
            return NoContent();
        }
    }
}
