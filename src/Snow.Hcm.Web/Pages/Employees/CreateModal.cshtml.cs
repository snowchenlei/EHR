using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Masuit.Tools.Systems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snow.Hcm.EmployeeManagement.Employees;
using Snow.Hcm.EmployeeManagement.Employees.Dtos;
using Snow.Hcm.Web.ViewModel.Employees;

namespace Snow.Hcm.Web.Pages.Employees
{
    public class CreateModalModel : HcmPageModel
    {
        private readonly IEmployeeAppService _employeeAppService;

        public CreateModalModel([NotNull] IEmployeeAppService bookAppService)
        {
            _employeeAppService = bookAppService ?? throw new ArgumentNullException(nameof(bookAppService));
        }

        [BindProperty] public EmployeeCreateViewModel Employee { get; set; }
        
        //public List<SelectListItem> Positions { get; set; }

        //public List<SelectListItem> Departments { get; set; }
        public List<SelectListItem> Calendars { get; set; }

        public async Task OnGetAsync()
        {
            Employee = new EmployeeCreateViewModel();
            Calendars = typeof(Calendar).GetDescriptionAndValue()
                .Select(r =>
                new SelectListItem(r.Key, r.Value.ToString())).ToList();
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
