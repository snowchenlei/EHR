using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snow.Hcm.EmployeeManagement.Departments;
using Snow.Hcm.EmployeeManagement.Positions;
using Snow.Hcm.Web.ViewModel.Components.Positions;
using Volo.Abp;

namespace Snow.Hcm.Web.ViewComponents
{
    public class PositionViewComponent : ViewComponent
    {
        private readonly IDepartmentAppService _departmentAppService;
        private readonly IPositionAppService _positionAppService;
        
        public PositionViewComponent([NotNull] IDepartmentAppService departmentAppService,
            [NotNull] IPositionAppService positionAppService)
        {
            _departmentAppService = departmentAppService ?? throw new ArgumentNullException(nameof(departmentAppService));
            _positionAppService = positionAppService ?? throw new ArgumentNullException(nameof(positionAppService));
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? positionId)
        {
            PositionComponentModel model = new PositionComponentModel();
            if (positionId.HasValue)
            {
                var dto = await _positionAppService.GetEditorAsync(positionId.Value)
                    ?? throw new UserFriendlyException("岗位不存在!");
                
                var departmentDtos = await _departmentAppService
                    .GetAllListAsync();
                model.Departments = departmentDtos.Items.Select(r =>
                    new SelectListItem(r.Name, r.Id.ToString(), r.Id == dto.DepartmentId)).ToList();

                var positions = await _positionAppService.GetListAsync(departmentDtos.Items.First().Id);
                model.Positions = positions.Items.Select(r =>
                    new SelectListItem(r.Name, r.Id.ToString(), r.Id == positionId.Value)).ToList();
            }
            else
            {
                var departmentDtos = await _departmentAppService
                    .GetAllListAsync();
                model.Departments = departmentDtos.Items.Select(r =>
                    new SelectListItem(r.Name, r.Id.ToString())).ToList();

                var positions = await _positionAppService.GetListAsync(departmentDtos.Items.First().Id);
                model.Positions = positions.Items.Select(r =>
                    new SelectListItem(r.Name, r.Id.ToString())).ToList();
            }

            return View(model);
        }
    }
}
