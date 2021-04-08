using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snow.Hcm.Web.ViewModel.Departments;

namespace Snow.Hcm.Web.Pages.Departments
{
    public class CreateModalModel : PageModel
    {
        [BindProperty] public DepartmentCreateViewModel Department { get; set; }
        public void OnGet()
        {
            Department = new DepartmentCreateViewModel();
        }
    }
}
