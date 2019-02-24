using LIMSCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LIMSInfrastructure.Services.Property
{
	public interface IParcelService
	{
		Parcel GetByNumber(string parcelNumber);
		IEnumerable<Parcel> GetAll();
		IEnumerable<Parcel> GetFilteredParcels(string searchQuery);
		IEnumerable<Parcel> GetParcelsByOwner(string OwnerId);
		Task Add(Parcel parcel);
		Task Delete(string parcelNumber);
		Task Update(string parcelNumber);
	}
}
