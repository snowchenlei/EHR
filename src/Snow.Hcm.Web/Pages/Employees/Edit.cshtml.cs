using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Masuit.Tools.Systems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snow.Hcm.EmployeeManagement.Employees;
using Snow.Hcm.EmployeeManagement.Employees.Dtos;
using Snow.Hcm.Web.ViewModel.Employees;

namespace Snow.Hcm.Web.Pages.Employees
{
    public class EditModel : HcmPageModel
    {
        private readonly IEmployeeAppService _employeeAppService;

        public EditModel(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        [BindProperty]
        public EmployeeEditViewModel Employee { get; set; }
        public List<SelectListItem> Departments { get; set; }

        public List<SelectListItem> Calendars { get; set; }

        public async Task OnGetAsync(Guid id)
        {
            var dto = await _employeeAppService.GetEditorAsync(id);
            Employee = ObjectMapper.Map<GetEmployeeForEditorOutput, EmployeeEditViewModel>(dto);
            Employee.Id = id;
            Employee.Calendar = dto.IsGregorianCalendar ? Calendar.GregorianCalendar : Calendar.ChineseCalendar;

            Calendars = typeof(Calendar).GetDescriptionAndValue()
                .Select(r =>
                new SelectListItem(r.Key, r.Value.ToString())).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<EmployeeEditViewModel, EmployeeUpdateDto>(Employee);
            dto.IsGregorianCalendar = Employee.Calendar == Calendar.GregorianCalendar ? true : false;
            await _employeeAppService.UpdateAsync(Employee.Id, dto);
            return NoContent();
        }
    }
}
