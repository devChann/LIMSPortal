using System.Collections.Generic;
using System.Threading.Tasks;
using LIMS.Core.Entities;

namespace LIMS.Infrastructure.Services.Property
{
	public interface IParcelService
	{
		Task AddParcel(Parcel parcel);
		Task DeleteParcel(string parcelNumber);
		IEnumerable<Parcel> GetAllParcels();
		IEnumerable<Parcel> GetFilteredParcels(string searchQuery);
		Parcel GetParcelByNumber(string number);
		Parcel GetParcelById(int id);
		Owner GetParcelOwnerByIdNumber(string id);
		Owner GetParcelOwnerByUsername(string name);
		IEnumerable<Parcel> GetParcelsByOwner(string id);
		Task UpdateParcel(string number);
	}
}
