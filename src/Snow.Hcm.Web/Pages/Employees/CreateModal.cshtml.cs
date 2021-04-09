using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lzez.Tendering.Admin.Enums;
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
        private readonly IEnumAppService _enumAppService;
        private readonly IRegionAppService _regionAppService;
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IDepartmentAppService _departmentAppService;

        public CreateModalModel([NotNull] IEmployeeAppService bookAppService,
            [NotNull] IRegionAppService regionAppService,
            [NotNull] IEnumAppService enumAppService,
            [NotNull] IDepartmentAppService departmentAppService)
        {
            _employeeAppService = bookAppService ?? throw new ArgumentNullException(nameof(bookAppService));
            _regionAppService = regionAppService ?? throw new ArgumentNullException(nameof(regionAppService));
            _enumAppService = enumAppService ?? throw new ArgumentNullException(nameof(enumAppService));
            _departmentAppService = departmentAppService ?? throw new ArgumentNullException(nameof(departmentAppService));
        }

        [BindProperty] public EmployeeCreateViewModel Employee { get; set; }

        public List<SelectListItem> Provinces { get; set; }
        public List<SelectListItem> Cities { get; set; }
        public List<SelectListItem> Areas { get; set; }
        public List<SelectListItem> Departments { get; set; }

        public List<SelectListItem> Genders { get; set; }

        public async Task OnGetAsync()
        {
            Employee = new EmployeeCreateViewModel();
            Genders = (await _enumAppService.GetGenderAsync())
                .Select(r =>
                new SelectListItem(r.Key, r.Value.ToString())).ToList();
            var provinces = await _regionAppService
                .GetChildrenAsync(100000);
            var cities = await _regionAppService
                .GetChildrenAsync(provinces.Items.First().Id);
            var areas = await _regionAppService
                .GetChildrenAsync(cities.Items.First().Id);
            var departments = await _departmentAppService
                .GetAllListAsync();
            Provinces = provinces.Items.Select(r => 
                new SelectListItem(r.Name, r.Id.ToString())).ToList();
            Cities = cities.Items.Select(r =>
                new SelectListItem(r.Name, r.Id.ToString())).ToList();
            Areas = areas.Items.Select(r =>
                new SelectListItem(r.Name, r.Id.ToString())).ToList();
            Departments = departments.Items.Select(r =>
                new SelectListItem(r.Name, r.Id.ToString())).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _employeeAppService.CreateAsync(ObjectMapper.Map<EmployeeCreateViewModel, EmployeeCreateDto>(Employee));
            return NoContent();
        }
    }
}
