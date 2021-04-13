using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Masuit.Tools.Systems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snow.Hcm.EmployeeManagement.Departments;
using Snow.Hcm.EmployeeManagement.Employees;
using Snow.Hcm.EmployeeManagement.Employees.Dtos;
using Snow.Hcm.Web.ViewModel.Employees;

namespace Snow.Hcm.Web.Pages.Employees
{
    public class EditModalModel : HcmPageModel
    {
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IDepartmentAppService _departmentAppService;

        public EditModalModel(IEmployeeAppService employeeAppService, 
            IDepartmentAppService departmentAppService)
        {
            _employeeAppService = employeeAppService;
            _departmentAppService = departmentAppService;
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
            var departments = await _departmentAppService
               .GetAllListAsync();
            Departments = departments.Items.Select(r =>
                new SelectListItem(r.Name, r.Id.ToString())).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _employeeAppService.UpdateAsync(Employee.Id,ObjectMapper.Map<EmployeeEditViewModel, EmployeeUpdateDto>(Employee));
            return NoContent();
        }
    }
}
