using Braintree;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIMS.Infrastructure.Services.Payment
{
	public class BraintreeService : IBraintreeService
	{
		public static readonly TransactionStatus[] transactionSuccessStatuses = {

			TransactionStatus.AUTHORIZED,

			TransactionStatus.AUTHORIZING,

			TransactionStatus.SETTLED,

			TransactionStatus.SETTLING,

			TransactionStatus.SETTLEMENT_CONFIRMED,

			TransactionStatus.SETTLEMENT_PENDING,

			TransactionStatus.SUBMITTED_FOR_SETTLEMENT
		};



		public string GetClientToken()
		{
			var gateway = GetGateway();

			var clientToken = gateway.ClientToken.Generate();

			return clientToken;

		}

		public IBraintreeGateway GetGateway()
		{
			return new BraintreeGateway
			{
				Environment = Braintree.Environment.SANDBOX,
				MerchantId = "q7f5m7b2d69z5jnp",				
				PublicKey = "5fy58dhwcch3tj3f",
				PrivateKey = "d3adabd1c38bdb4bce847338da689d66"
			};
		}
	}
}
