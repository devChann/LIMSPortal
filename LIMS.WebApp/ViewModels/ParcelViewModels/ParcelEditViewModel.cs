using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LIMS.WebApp.ViewModels.ParcelViewModels
{
	public class ParcelEditViewModel
	{

		public Guid ParcelId { get; set; }

		[Required]
		[Display(Name = "Parcel Number")]
		public string ParcelNumber { get; set; }

		[Required]
		[Display(Name = "Area")]
		public double? Area { get; set; }

		[Required]
		[Display(Name = "District")]
		public Guid SelectedDistrict { get; set; }
		public IEnumerable<SelectListItem> Districts { get; set; }

		[Required]
		[Display(Name = "Block")]
		public Guid SelectedBlock { get; set; }
		public IEnumerable<SelectListItem> Blocks { get; set; }		

		[Required]
		[Display(Name = "Land Use")]
		public Guid SelectedLandUse { get; set; }
		public IEnumerable<SelectListItem> LandUses { get; set; }
	}
}
