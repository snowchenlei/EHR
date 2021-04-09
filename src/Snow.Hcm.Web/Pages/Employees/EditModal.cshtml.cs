using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snow.Hcm.EmployeeManagement.Employees;
using Snow.Hcm.EmployeeManagement.Employees.Dtos;
using Snow.Hcm.Web.ViewModel.Employees;

namespace Snow.Hcm.Web.Pages.Employees
{
    public class EditModalModel : HcmPageModel
    {
        private readonly IEmployeeAppService _employeeAppService;

        public EditModalModel(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        [BindProperty]
        public EmployeeEditViewModel Employee { get; set; }
        
        public async Task OnGetAsync(Guid id)
        {
            var dto = await _employeeAppService.GetEditorAsync(id);
            Employee = ObjectMapper.Map<GetEmployeeForEditorOutput, EmployeeEditViewModel>(dto);
            Employee.Id = id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _employeeAppService.UpdateAsync(Employee.Id,ObjectMapper.Map<EmployeeEditViewModel, EmployeeUpdateDto>(Employee));
            return NoContent();
        }
    }
}
