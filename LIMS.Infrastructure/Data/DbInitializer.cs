using LIMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LIMS.Infrastructure.Data
{
	public static class DbInitializer
	{
		public static void Initialize(LIMSCoreDbContext context)
		{
			context.Database.EnsureCreated();

			// Look for any students.
			if (context.Parcel.Any())
			{
				return;   // DB has been seeded
			}

			var parcels = new Parcel[]
			{
				new Parcel{ParcelNum="", AdministrationId=Guid.NewGuid(), Area = 30.55, LandUseId = Guid.NewGuid(),
					OwnerId = Guid.NewGuid(),OwnershipRightId=Guid.NewGuid(),RateId=Guid.NewGuid(),RegistrationId=Guid.NewGuid(), ResponsibilityId=Guid.NewGuid(),RestrictionId=Guid.NewGuid(),SpatialUnitId=Guid.NewGuid(),ValuationId=Guid.NewGuid()},

				new Parcel{ParcelNum="", AdministrationId=Guid.NewGuid(), Area = 39.65, LandUseId = Guid.NewGuid(),
					OwnerId = Guid.NewGuid(),OwnershipRightId=Guid.NewGuid(),RateId=Guid.NewGuid(),RegistrationId=Guid.NewGuid(), ResponsibilityId=Guid.NewGuid(),RestrictionId=Guid.NewGuid(),SpatialUnitId=Guid.NewGuid(),ValuationId=Guid.NewGuid()},

				new Parcel{ParcelNum="", AdministrationId=Guid.NewGuid(), Area = 33.45, LandUseId = Guid.NewGuid(),
					OwnerId = Guid.NewGuid(),OwnershipRightId=Guid.NewGuid(),RateId=Guid.NewGuid(),RegistrationId=Guid.NewGuid(), ResponsibilityId=Guid.NewGuid(),RestrictionId=Guid.NewGuid(),SpatialUnitId=Guid.NewGuid(),ValuationId=Guid.NewGuid()}
			};
			foreach (var p in parcels)
			{
				context.Parcel.Add(p);
			}
		
			context.SaveChanges();

			//var administrations = new Administration[]
			//{
			//	new Administration{},
			//	new Administration{},
			//	new Administration{}			
			//};
			//foreach (var a in administrations)
			//{
			//	context.Administration.Add(a);
			//}
			//context.SaveChanges();

			//var apartments = new Apartment[]
			//{
			//	new Apartment{},
			//	new Apartment{},
			//	new Apartment{},
			//	new Apartment{},
			//	new Apartment{}			
			//};
			//foreach (var ap in apartments)
			//{
			//	context.Apartment.Add(ap);
			//}


			//context.SaveChanges();
		}
	}
}
