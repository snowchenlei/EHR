using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Snow.Hcm.Web.ViewModel.Positions
{
    public class PositionEditViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public Guid DepartmentId { get; set; }
    }
}
