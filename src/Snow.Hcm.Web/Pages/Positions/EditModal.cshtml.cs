using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snow.Hcm.EmployeeManagement.Departments;
using Snow.Hcm.EmployeeManagement.Positions;
using Snow.Hcm.EmployeeManagement.Positions.Dtos;
using Snow.Hcm.Web.ViewModel.Positions;

namespace Snow.Hcm.Web.Pages.Positions
{
    public class EditModalModel : HcmPageModel
    {
        private readonly IPositionAppService _positionAppService;
        private readonly IDepartmentAppService _departmentAppService;

        public EditModalModel(IPositionAppService positionAppService, IDepartmentAppService departmentAppService)
        {
            _positionAppService = positionAppService;
            _departmentAppService = departmentAppService;
        }

        [BindProperty]
        public PositionEditViewModel Position { get; set; }


        public List<SelectListItem> Departments { get; set; }
        public async Task OnGetAsync(Guid id)
        {
            var dto = await _positionAppService.GetEditorAsync(id);
            Position = ObjectMapper.Map<GetPositionForEditorOutput, PositionEditViewModel>(dto);
            Position.Id = id;

            Departments = (await _departmentAppService.GetAllListAsync())
                .Items
                .Select(d => new SelectListItem(d.Name, d.Id.ToString("D")))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _positionAppService.UpdateAsync(Position.Id, ObjectMapper.Map<PositionEditViewModel, PositionUpdateDto>(Position));
            return NoContent();
        }
    }
}
