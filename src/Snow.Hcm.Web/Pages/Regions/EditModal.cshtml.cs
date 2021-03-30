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
    public class EditModalModel : HcmPageModel
    {
        private readonly IRegionAppService _regionAppService;

        public EditModalModel(IRegionAppService regionAppService)
        {
            _regionAppService = regionAppService;
        }

        public List<SelectListItem> Regions { get; set; }

        public RegionEditViewModel Region { get; set; }

        public async Task OnGetAsync(int id)
        {
            var dto = await _regionAppService.GetEditorAsync(id);
            Region = ObjectMapper.Map<GetRegionForEditOutput, RegionEditViewModel>(dto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<RegionEditViewModel, RegionUpdateDto>(Region);
            await _regionAppService.UpdateAsync(Region.Id, dto);
            return NoContent();
        }
    }
}
