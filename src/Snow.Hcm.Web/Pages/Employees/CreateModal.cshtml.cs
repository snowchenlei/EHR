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
    public class CreateModalModel : HcmPageModel
    {
        [BindProperty]
        public EmployeeCreateViewModel Employee { get; set; }

        private readonly IEmployeeAppService _bookAppService;

        public CreateModalModel(IEmployeeAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        public void OnGet()
        {
            Employee = new EmployeeCreateViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.CreateAsync(ObjectMapper.Map<EmployeeCreateViewModel, EmployeeCreateDto>(Employee));
            return NoContent();
        }
    }
}
