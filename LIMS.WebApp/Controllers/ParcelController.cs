using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LIMS.Core.Entities;
using LIMS.Infrastructure.Data;
using LIMS.WebApp.ViewModels.ParcelViewModels;
using Microsoft.AspNetCore.Authorization;
using LIMS.Infrastructure.Services.Properties;

namespace LIMS.WebApp.Controllers
{
	[Authorize]
	public class ParcelController : Controller
	{
		private readonly LIMSCoreDbContext _context;
		private readonly IParcelService _parcelService;

		public ParcelController(LIMSCoreDbContext context, IParcelService parcelService)
		{
			_context = context;
			_parcelService = parcelService;
		}

		// GET: Parcels
		public async Task<IActionResult> Index()
		{		
			return View(await _parcelService.GetParcels());
		}

		// GET: Parcel/Details/5
		public async Task<IActionResult> Details(Guid? id)
		{
			//this check is not honest
			if (id == null)
			{
				return BadRequest();
			}

			var parcel = await _parcelService.GetParcel(id);

			if (parcel == null)
			{
				return NotFound();
			}

			return View(parcel);
		}

		// GET: Parcel/Create
		[Authorize(Roles = "Administrator")]
		public IActionResult Create()
		{
			ViewData["AdministrationId"] = new SelectList(_context.Administration, "AdministrationId", "AdministrationId");
			ViewData["LandUseId"] = new SelectList(_context.LandUse, "LandUseId", "LandUseId");
			ViewData["OwnerId"] = new SelectList(_context.Owner, "OwnerId", "OwnerId");
			ViewData["OwnershipRightId"] = new SelectList(_context.OwnershipRight, "OwnershipRightId", "OwnershipRightId");
			ViewData["RateId"] = new SelectList(_context.Rate, "RateId", "RateId");
			ViewData["RegistrationId"] = new SelectList(_context.Registration, "RegistrationId", "RegistrationId");
			ViewData["ResponsibilityId"] = new SelectList(_context.Responsibility, "ResponsibilityId", "ResponsibilityId");
			ViewData["RestrictionId"] = new SelectList(_context.Restriction, "RestrictionId", "RestrictionId");
			ViewData["SpatialUnitId"] = new SelectList(_context.SpatialUnit, "SpatialUnitId", "SpatialUnitId");
			ViewData["TenureId"] = new SelectList(_context.Tenure, "TenureId", "TenureId");
			ViewData["ValuationId"] = new SelectList(_context.Valuation, "ValuationId", "ValuationId");
			return View();
		}

		// POST: Parcel/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize(Roles = "Administrator")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ParcelId,Area,ParcelNum,AdministrationId,LandUseId,OwnerId,OwnershipRightId,RateId,RegistrationId,ResponsibilityId,RestrictionId,SpatialUnitId,TenureId,ValuationId")] Parcel parcel)
		{
			if (ModelState.IsValid)
			{
				_context.Add(parcel);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["AdministrationId"] = new SelectList(_context.Administration, "AdministrationId", "AdministrationId", parcel.AdministrationId);
			ViewData["LandUseId"] = new SelectList(_context.LandUse, "LandUseId", "LandUseId", parcel.LandUseId);
			ViewData["OwnerId"] = new SelectList(_context.Owner, "OwnerId", "OwnerId", parcel.OwnerId);
			ViewData["OwnershipRightId"] = new SelectList(_context.OwnershipRight, "OwnershipRightId", "OwnershipRightId", parcel.OwnershipRightId);
			ViewData["RateId"] = new SelectList(_context.Rate, "RateId", "RateId", parcel.RateId);
			ViewData["RegistrationId"] = new SelectList(_context.Registration, "RegistrationId", "RegistrationId", parcel.RegistrationId);
			ViewData["ResponsibilityId"] = new SelectList(_context.Responsibility, "ResponsibilityId", "ResponsibilityId", parcel.ResponsibilityId);
			ViewData["RestrictionId"] = new SelectList(_context.Restriction, "RestrictionId", "RestrictionId", parcel.RestrictionId);
			ViewData["SpatialUnitId"] = new SelectList(_context.SpatialUnit, "SpatialUnitId", "SpatialUnitId", parcel.SpatialUnitId);
			ViewData["TenureId"] = new SelectList(_context.Tenure, "TenureId", "TenureId", parcel.TenureId);
			ViewData["ValuationId"] = new SelectList(_context.Valuation, "ValuationId", "ValuationId", parcel.ValuationId);
			return View(parcel);
		}

		// GET: Parcel/Edit/5
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Edit(Guid? id)
		{
			if (id == null)
			{
				return BadRequest();
			}

			var parcel = await _context.Parcel.FindAsync(id);

			if (parcel == null)
			{
				return NotFound();
			}

			var Blocks = new SelectList(_context.Administration, "AdministrationId", "BlockName", parcel.AdministrationId);

			var Districts = new SelectList(_context.Administration, "AdministrationId", "DistrictName", parcel.AdministrationId);

			var LandUses = new SelectList(_context.LandUse, "LandUseId", "LandUseType", parcel.LandUseId);

			var Owners = new SelectList(_context.Owner, "OwnerId", "OwnerId", parcel.OwnerId);

			var Rights = new SelectList(_context.OwnershipRight, "OwnershipRightId", "OwnershipRightId", parcel.OwnershipRightId);

			var Rates = new SelectList(_context.Rate, "RateId", "RateId", parcel.RateId);

			var Registrations = new SelectList(_context.Registration, "RegistrationId", "RegistrationId", parcel.RegistrationId);

			var Responsibilities = new SelectList(_context.Responsibility, "ResponsibilityId", "ResponsibilityType", parcel.ResponsibilityId);

			var Restrictions = new SelectList(_context.Restriction, "RestrictionId", "RestrictionId", parcel.RestrictionId);

			var SpatialUnits = new SelectList(_context.SpatialUnit, "SpatialUnitId", "SpatialUnitId", parcel.SpatialUnitId);

			var Tenures = new SelectList(_context.Tenure, "TenureId", "TenureId", parcel.TenureId);

			var valuations = new SelectList(_context.Valuation, "ValuationId", "ValuationId", parcel.ValuationId);

			var parcelviewmodel = new ParcelEditViewModel
			{
				ParcelId = parcel.ParcelId,
				ParcelNumber = parcel.ParcelNum,
				Area = parcel.Area,

				SelectedBlock = parcel.AdministrationId,
				Blocks = Blocks,

				SelectedDistrict = parcel.AdministrationId,
				Districts = Districts,

				SelectedLandUse = parcel.LandUseId,
				LandUses = LandUses,

				SelectedOwner = parcel.OwnerId,
				Owners = Owners,

				SelectedRight = parcel.OwnershipRightId,
				Rights =Rights,

				SelectedRate = parcel.RateId,
				Rates = Rates,

				SelectedRegistration = parcel.RegistrationId,
				Registrations = Registrations,

				SelectedResponsibility = parcel.ResponsibilityId,
				Responsibilities = Responsibilities,

				SelectedRestriction = parcel.RestrictionId,
				Restrictions = Restrictions,

				SelectedSpatialUnit = parcel.SpatialUnitId,
				SpatialUnits = SpatialUnits,

				SelectedTenure = parcel.TenureId,
				Tenures = Tenures,

				SelectedValuation = parcel.ValuationId,
				Valuations = valuations


			};

			return View(parcelviewmodel);
		}

		// POST: Parcel/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize(Roles = "Administrator")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(ParcelEditViewModel parceledit)
		{
			var parcel = await _context.Parcel.FindAsync(parceledit.ParcelId);

			if (parcel == null)
			{
				return NotFound();
			}

			parcel.LandUseId = parceledit.SelectedLandUse;
			parcel.Area = parceledit.Area;
			parcel.ParcelNum = parceledit.ParcelNumber;
			parcel.AdministrationId = parceledit.SelectedBlock;			

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(parcel);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ParcelExists(parcel.ParcelId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			//ViewData["AdministrationId"] = new SelectList(_context.Administration, "AdministrationId", "AdministrationId", parcel.AdministrationId);
			//ViewData["LandUseId"] = new SelectList(_context.LandUse, "LandUseId", "LandUseId", parcel.LandUseId);
			//ViewData["OwnerId"] = new SelectList(_context.Owner, "OwnerId", "OwnerId", parcel.OwnerId);
			//ViewData["OwnershipRightId"] = new SelectList(_context.OwnershipRight, "OwnershipRightId", "OwnershipRightId", parcel.OwnershipRightId);
			//ViewData["RateId"] = new SelectList(_context.Rate, "RateId", "RateId", parcel.RateId);
			//ViewData["RegistrationId"] = new SelectList(_context.Registration, "RegistrationId", "RegistrationId", parcel.RegistrationId);
			//ViewData["ResponsibilityId"] = new SelectList(_context.Responsibility, "ResponsibilityId", "ResponsibilityId", parcel.ResponsibilityId);
			//ViewData["RestrictionId"] = new SelectList(_context.Restriction, "RestrictionId", "RestrictionId", parcel.RestrictionId);
			//ViewData["SpatialUnitId"] = new SelectList(_context.SpatialUnit, "SpatialUnitId", "SpatialUnitId", parcel.SpatialUnitId);
			//ViewData["TenureId"] = new SelectList(_context.Tenure, "TenureId", "TenureId", parcel.TenureId);
			//ViewData["ValuationId"] = new SelectList(_context.Valuation, "ValuationId", "ValuationId", parcel.ValuationId);
			return View(parceledit);
		}

		// GET: Parcel/Delete/5
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null)
			{
				return BadRequest();
			}

			var parcel = await _context.Parcel
				.Include(p => p.Administration)
				.Include(p => p.LandUse)
				.Include(p => p.Owner)
				.Include(p => p.OwnershipRight)
				.Include(p => p.Rate)
				.Include(p => p.Registration)
				.Include(p => p.Responsibility)
				.Include(p => p.Restriction)
				.Include(p => p.SpatialUnit)
				.Include(p => p.Tenure)
				.Include(p => p.Valuation)
				.FirstOrDefaultAsync(m => m.ParcelId == id);
			if (parcel == null)
			{
				return NotFound();
			}

			return View(parcel);
		}

		// POST: Parcel/Delete/5
		[Authorize(Roles = "Administrator")]
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var parcel = await _context.Parcel.FindAsync(id);
			_context.Parcel.Remove(parcel);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ParcelExists(Guid id)
		{
			return _context.Parcel.Any(e => e.ParcelId == id);
		}
	}
}
