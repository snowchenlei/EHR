using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snow.Hcm.Web.ViewModel.Components.Regions
{
    public class RegionComponentModel
    {
        public List<SelectListItem> Provinces { get; set; }
        public List<SelectListItem> Cities { get; set; }
        public List<SelectListItem> Areas { get; set; }

    }
}
