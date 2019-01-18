using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LIMSWebApp.ViewModels.ParcelViewModels
{
	public class ParcelEditViewModel
	{

		public int ParcelId { get; set; }

		[Required]
		[Display(Name = "Parcel Number")]
		public string ParcelNumber { get; set; }

		[Required]
		[Display(Name = "Area")]
		public double? Area { get; set; }

		[Required]
		[Display(Name = "District")]
		public int SelectedDistrict { get; set; }
		public IEnumerable<SelectListItem> Districts { get; set; }

		[Required]
		[Display(Name = "Block")]
		public int SelectedBlock { get; set; }
		public IEnumerable<SelectListItem> Blocks { get; set; }		

		[Required]
		[Display(Name = "Land Use")]
		public int SelectedLandUse { get; set; }
		public IEnumerable<SelectListItem> LandUses { get; set; }
	}
}
