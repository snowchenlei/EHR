using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snow.Hcm.EmployeeManagement.Employees;
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
        
        public async Task OnGetAsync(Guid employeeId)
        {
            await _employeeAppService.GetEditorAsync(employeeId);
        }
    }
}
