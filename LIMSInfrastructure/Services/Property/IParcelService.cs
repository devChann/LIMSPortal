using System.Collections.Generic;
using System.Threading.Tasks;
using LIMSCore.Entities;

namespace LIMSInfrastructure.Services.Property
{
	public interface IParcelService
	{
		Task AddParcel(Parcel parcel);
		Task DeleteParcel(string parcelNumber);
		IEnumerable<Parcel> GetAllParcels();
		IEnumerable<Parcel> GetFilteredParcels(string searchQuery);
		Parcel GetParcelByNumber(string parcelNumber);
		Parcel GetParcelById(int id);
		Owner GetParcelOwnerByIdNumber(string IDNumber);
		Owner GetParcelOwnerByUsername(string UserName);
		IEnumerable<Parcel> GetParcelsByOwner(string OwnerId);
		Task UpdateParcel(string parcelNumber);
	}
}
