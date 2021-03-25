using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snow.Hcm.Web.ViewModel.Regions;
using Snow.RegionManagement.Admin.Regions;

namespace Snow.Hcm.Web.Pages.Regions
{
    public class CreateModalModel : PageModel
    {
        private readonly IRegionAppService _regionAppService;

        public CreateModalModel(IRegionAppService regionAppService)
        {
            _regionAppService = regionAppService;
        }

        [BindProperty]
        public RegionCreateViewModel Region { get; set; }

        public void OnGet()
        {
            Region = new RegionCreateViewModel();
        }
    }
}
