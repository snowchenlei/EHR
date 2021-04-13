using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snow.Hcm.Web.ViewModel.Components.Regions;
using Snow.RegionManagement.Admin.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snow.Hcm.Web.ViewComponents
{
    /// <summary>
    /// 省市区联动
    /// </summary>
    public class RegionViewComponent : ViewComponent
    {
        private readonly IRegionAppService _regionAppService;

        public RegionViewComponent(IRegionAppService regionAppService)
        {
            _regionAppService = regionAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int parentId)
        {
            var provinces = await _regionAppService
               .GetChildrenAsync(parentId);
            var cities = await _regionAppService
                .GetChildrenAsync(provinces.Items.First().Id);
            var areas = await _regionAppService
                .GetChildrenAsync(cities.Items.First().Id);

            return View(new RegionComponentModel
            {
                Provinces = provinces.Items.Select(r =>
                    new SelectListItem(r.Name, r.Id.ToString())).ToList(),
                Cities = cities.Items.Select(r =>
                    new SelectListItem(r.Name, r.Id.ToString())).ToList(),
                Areas = areas.Items.Select(r =>
                    new SelectListItem(r.Name, r.Id.ToString())).ToList()
            });
        }
    }
}
