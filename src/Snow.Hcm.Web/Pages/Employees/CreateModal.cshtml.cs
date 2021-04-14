using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lzez.Tendering.Admin.Enums;
using Masuit.Tools.Systems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snow.Hcm.EmployeeManagement.Departments;
using Snow.Hcm.EmployeeManagement.Employees;
using Snow.Hcm.EmployeeManagement.Employees.Dtos;
using Snow.Hcm.Web.ViewModel.Employees;
using Snow.RegionManagement.Admin.Regions;

namespace Snow.Hcm.Web.Pages.Employees
{
    public class CreateModalModel : HcmPageModel
    {
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IDepartmentAppService _departmentAppService;

        public CreateModalModel([NotNull] IEmployeeAppService bookAppService,
            [NotNull] IDepartmentAppService departmentAppService)
        {
            _employeeAppService = bookAppService ?? throw new ArgumentNullException(nameof(bookAppService));
            _departmentAppService = departmentAppService ?? throw new ArgumentNullException(nameof(departmentAppService));
        }

        [BindProperty] public EmployeeCreateViewModel Employee { get; set; }

        public List<SelectListItem> Departments { get; set; }

        public List<SelectListItem> Calendars { get; set; }

        public async Task OnGetAsync()
        {
            Employee = new EmployeeCreateViewModel();
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
            var dto = ObjectMapper.Map<EmployeeCreateViewModel, EmployeeCreateDto>(Employee);
            dto.IsGregorianCalendar = Employee.Calendar == Calendar.GregorianCalendar ? true : false;
            await _employeeAppService.CreateAsync(dto);
            return NoContent();
        }
    }
}
