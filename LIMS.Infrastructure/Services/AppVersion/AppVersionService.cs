using System.Reflection;

namespace LIMS.Infrastructure.Services.AppVersion
{
	public class AppVersionService : IAppVersionService
	{
		public string Version =>
			Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
	}
}
