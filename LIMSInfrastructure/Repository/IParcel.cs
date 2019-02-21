using LIMSCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LIMSInfrastructure.Repository
{
	public interface IParcel
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
