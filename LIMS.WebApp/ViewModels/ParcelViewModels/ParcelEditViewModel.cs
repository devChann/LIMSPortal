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

		[Required]
		[Display(Name = "Owners")]
		public Guid SelectedOwner { get; set; }
		public IEnumerable<SelectListItem> Owners { get; set; }

		[Required]
		[Display(Name = "Rights")]
		public Guid SelectedRight { get; set; }
		public IEnumerable<SelectListItem> Rights { get; set; }

		[Required]
		[Display(Name = "Rates")]
		public Guid SelectedRate{ get; set; }
		public IEnumerable<SelectListItem> Rates { get; set; }

		[Required]
		[Display(Name = "Registrations")]
		public Guid SelectedRegistration { get; set; }
		public IEnumerable<SelectListItem> Registrations { get; set; }


		[Required]
		[Display(Name = "Responsibilities")]
		public Guid SelectedResponsibility { get; set; }
		public IEnumerable<SelectListItem> Responsibilities { get; set; }

		[Required]
		[Display(Name = "Restrictions")]
		public Guid SelectedRestriction { get; set; }
		public IEnumerable<SelectListItem> Restrictions { get; set; }

		[Required]
		[Display(Name = "SpatialUnits")]
		public Guid SelectedSpatialUnit { get; set; }
		public IEnumerable<SelectListItem> SpatialUnits { get; set; }

		[Required]
		[Display(Name = "Tenures")]
		public Guid SelectedTenure { get; set; }
		public IEnumerable<SelectListItem> Tenures { get; set; }


		[Required]
		[Display(Name = "Valuations")]
		public Guid SelectedValuation { get; set; }
		public IEnumerable<SelectListItem> Valuations { get; set; }

	}
}
