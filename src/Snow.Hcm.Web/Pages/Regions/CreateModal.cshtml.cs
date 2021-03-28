using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snow.Hcm.Web.ViewModel.Regions;
using Snow.RegionManagement.Admin.Regions;

namespace Snow.Hcm.Web.Pages.Regions
{
    public class CreateModalModel : HcmPageModel
    {
        private readonly IRegionAppService _regionAppService;
        public List<SelectListItem> Regions { get; set; }
        public CreateModalModel(IRegionAppService regionAppService)
        {
            _regionAppService = regionAppService;
        }

        [BindProperty]
        public RegionCreateViewModel Region { get; set; }

        public async Task OnGetAsync()
        {
            Regions = (await _regionAppService.GetListAsync(new GetRegionsInput()))
                .Items
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Id.ToString()
                })
                .ToList();
            Region = new RegionCreateViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<RegionCreateViewModel, RegionCreateDto>(Region);
            await _regionAppService.CreateAsync(dto);
            return NoContent();
        }
    }
}
