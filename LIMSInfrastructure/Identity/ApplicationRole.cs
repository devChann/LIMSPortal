using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIMSInfrastructure.Identity
{
    public class ApplicationRole: IdentityRole
    { 
        public string Description { get; set; }
        public DateTime CreatedDate  { get; set; }
        public string IPAddress { get; set; }
        public int Users { get; set; }
    }
}
