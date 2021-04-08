using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snow.Hcm.Web.ViewModel.Departments
{
    public class DepartmentEditViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
