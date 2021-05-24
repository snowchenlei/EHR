using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snow.Hcm.EmployeeManagement.Departments;
using Snow.Hcm.EmployeeManagement.Departments.Dtos;
using Snow.Hcm.Web.ViewModel.Departments;

namespace Snow.Hcm.Web.Pages.Departments
{
    public class CreateModalModel : HcmPageModel
    {
        private readonly IDepartmentAppService _departmentAppService;

        public CreateModalModel([NotNull] IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService 
                                    ?? throw new ArgumentNullException(nameof(departmentAppService));
        }

        [BindProperty] public DepartmentCreateViewModel Department { get; set; }
        public void OnGet()
        {
            Department = new DepartmentCreateViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _departmentAppService.CreateAsync(ObjectMapper.Map<DepartmentCreateViewModel, DepartmentCreateDto>(Department));
            return NoContent();
        }
    }
}
