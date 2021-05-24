using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Snow.Hcm.Web.ViewModel.Components.Positions
{
    public class PositionComponentModel
    {
        public List<SelectListItem> Departments { get; set; }
        public List<SelectListItem> Positions { get; set; }
    }
}
