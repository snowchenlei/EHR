using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snow.Hcm.EmployeeManagement.Employees;
using Snow.Hcm.EmployeeManagement.Employees.Dtos;
using Snow.Hcm.Web.ViewModel.Employees;
using Snow.RegionManagement.Admin.Regions;

namespace Snow.Hcm.Web.Pages.Employees
{
    public class CreateModalModel : HcmPageModel
    {

        private readonly IEmployeeAppService _bookAppService;
        private readonly IRegionAppService _regionAppService;

        public CreateModalModel([NotNull] IEmployeeAppService bookAppService,
            [NotNull] IRegionAppService regionAppService)
        {
            _bookAppService = bookAppService ?? throw new ArgumentNullException(nameof(bookAppService));
            _regionAppService = regionAppService ?? throw new ArgumentNullException(nameof(regionAppService));
        }

        [BindProperty] public EmployeeCreateViewModel Employee { get; set; }

        public List<SelectListItem> Provinces { get; set; }

        public async Task OnGetAsync()
        {
            Employee = new EmployeeCreateViewModel();
            var provinces = await _regionAppService
                .GetChildrenAsync(100000);
            Provinces = provinces.Items.Select(r => 
                new SelectListItem(r.Name, r.Id.ToString())).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.CreateAsync(ObjectMapper.Map<EmployeeCreateViewModel, EmployeeCreateDto>(Employee));
            return NoContent();
        }
    }
}
