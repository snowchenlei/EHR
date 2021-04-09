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
    public class EditModalModel : HcmPageModel
    {
        private readonly IDepartmentAppService _departmentAppService;

        public EditModalModel([NotNull] IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService ?? throw new ArgumentNullException(nameof(departmentAppService));
        }
        [BindProperty]
        public DepartmentEditViewModel Department { get; set; }

        public async Task OnGetAsync(Guid id)
        {
            var dto = await _departmentAppService.GetEditorAsync(id);
            Department = ObjectMapper.Map<GetDepartmentForEditorOutput, DepartmentEditViewModel>(dto);
            Department.Id = id;
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            await _departmentAppService.UpdateAsync(Department.Id, ObjectMapper.Map<DepartmentEditViewModel, DepartmentUpdateDto>(Department));
            return NoContent();
        }
    }
}
