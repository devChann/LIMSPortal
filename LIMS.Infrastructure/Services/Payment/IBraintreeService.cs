using Braintree;

namespace LIMS.Infrastructure.Services.Payment
{
	public interface IBraintreeService
	{
		string GetClientToken();
		IBraintreeGateway GetGateway();
	}
}
