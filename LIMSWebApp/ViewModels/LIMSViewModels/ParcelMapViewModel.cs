using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSWebApp.ViewModels.LIMSViewModels
{
    public class ParcelMapViewModel
    {
        public byte[] Geometry { get; set; }
        public string ParcelNum { get; set; }
    }
}
