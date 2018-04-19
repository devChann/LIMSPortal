using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSCore.ViewModels.ApplicationRoleView
{
    public class ApplicationRoleListView
    {
        public string id { get; set; }
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int NumberOfUsers { get; set; }
    }
}
