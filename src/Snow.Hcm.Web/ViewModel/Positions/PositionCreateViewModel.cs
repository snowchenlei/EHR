using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snow.Hcm.Web.ViewModel.Positions
{
    public class PositionCreateViewModel
    {
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
