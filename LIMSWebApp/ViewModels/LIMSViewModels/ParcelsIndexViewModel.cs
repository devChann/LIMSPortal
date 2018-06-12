using LIMSCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSWebApp.ViewModels.LIMSViewModels
{
    public class ParcelsIndexViewModel
    {
        public IEnumerable<Parcel> Parcels { get; set; }
        //public IEnumerable<RRRs> RRRs { get; set; }
        public IEnumerable<Owner> Owners { get; set; }
        
        //public IEnumerable<OwnerRRR> OwnerRRRs { get; set; }
        
       
    }
}
