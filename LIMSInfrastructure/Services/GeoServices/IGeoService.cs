namespace LIMSInfrastructure.Services.GeoServices
{
	public interface IGeoService
	{
		string GetLandParcel(string featurename, string attribute, string filter);
	}
}