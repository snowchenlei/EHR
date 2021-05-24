using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snow.Hcm.EmployeeManagement.Departments;
using Snow.Hcm.EmployeeManagement.Positions;
using Snow.Hcm.EmployeeManagement.Positions.Dtos;
using Snow.Hcm.Web.ViewModel.Positions;

namespace Snow.Hcm.Web.Pages.Positions
{
    public class CreateModalModel : HcmPageModel
    {
        private readonly IPositionAppService _positionAppService;
        private readonly IDepartmentAppService _departmentAppService;

        public CreateModalModel([NotNull] IPositionAppService positionAppService,
            [NotNull] IDepartmentAppService departmentAppService)
        {
            _positionAppService = positionAppService ?? throw new ArgumentNullException(nameof(positionAppService));
            _departmentAppService = departmentAppService ?? throw new ArgumentNullException(nameof(departmentAppService));
        }

        [BindProperty]
        public PositionCreateViewModel Position { get; set; }

        public List<SelectListItem> Departments { get; set; }
        
        public async Task OnGetAsync()
        {
            Departments = (await _departmentAppService.GetAllListAsync())
                .Items
                .Select(d => new SelectListItem(d.Name, d.Id.ToString("D")))
                .ToList();
            
            
            Position = new PositionCreateViewModel();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _positionAppService.CreateAsync(ObjectMapper.Map<PositionCreateViewModel, PositionCreateDto>(Position));
            return NoContent();
        }
    }
}
