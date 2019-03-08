using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMS.WebApp.ViewModels.LIMSViewModels
{
    public class ParcelMapViewModel
    {
        public byte[] Geometry { get; set; }
        public string ParcelNum { get; set; }
    }
}
