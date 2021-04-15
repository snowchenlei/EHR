using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snow.Hcm.Web.ViewModel.Components.Regions;
using Snow.RegionManagement.Admin.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

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

        public async Task<IViewComponentResult> InvokeAsync(int parentId, int? provinceId, int? cityId, int? areaId)
        {
            ListResultDto<RegionTreeNodeDto> provinces;
            ListResultDto<RegionTreeNodeDto> cities;
            ListResultDto<RegionTreeNodeDto> areas;
            if (provinceId.HasValue && cityId.HasValue && areaId.HasValue)
            {
                provinces = await _regionAppService
                    .GetChildrenAsync(parentId);
                cities = await _regionAppService
                    .GetChildrenAsync(provinceId.Value);
                areas = await _regionAppService
                    .GetChildrenAsync(cityId.Value);
            }
            else
            {
                provinces = await _regionAppService
                    .GetChildrenAsync(parentId);
                cities = await _regionAppService
                    .GetChildrenAsync(provinces.Items.First().Id);
                areas = await _regionAppService
                    .GetChildrenAsync(cities.Items.First().Id);
            }
            List<SelectListItem> provinceSelects = GetSelectListItem(provinceId, provinces.Items);
            List<SelectListItem> citySelects = GetSelectListItem(cityId, cities.Items);
            List<SelectListItem> areaSelects = GetSelectListItem(areaId, areas.Items);
            return View(new RegionComponentModel
            {
                Provinces = provinceSelects,
                Cities = citySelects,
                Areas = areaSelects
            });
        }

        private static List<SelectListItem> GetSelectListItem(int? regionId, IReadOnlyList<RegionTreeNodeDto> regions)
        {
            List<SelectListItem> selects = new List<SelectListItem>();
            foreach (var province in regions)
            {
                bool selected = false;
                if (regionId.HasValue && province.Id == regionId.Value)
                {
                    selected = true;
                }
                selects.Add(new SelectListItem(province.Name, province.Id.ToString(), selected));
            }
            return selects;
        }
    }
}
