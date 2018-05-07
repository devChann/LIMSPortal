using LIMSCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSWebApp.ViewModels.TransactionViewModels
{
    public class ServicesViewModel
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Meta { get; set; }
        public bool? Status { get; set; }
        public string Opid { get; set; }
        public string Comments { get; set; }

        public IEnumerable<Parcel> Parcels { get; set; }
        public IEnumerable<Rrr> RRRs { get; set; }
      
        [Display(Name ="Choose A service")]
        public List<SelectListItem> Operations { get; set; }

    }
}
