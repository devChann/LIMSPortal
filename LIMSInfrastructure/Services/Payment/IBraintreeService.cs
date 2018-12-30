using Braintree;

namespace LIMSInfrastructure.Services.Payment
{
	public interface IBraintreeService
	{
		string GetClientToken();
		IBraintreeGateway GetGateway();
	}
}
