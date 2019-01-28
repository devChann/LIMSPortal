﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LIMSInfrastructure.Services.Payment.Mpesa
{
	public class MpesaStkResponse
	{
		public string MerchantRequestID { get; set; }
		public string CheckoutRequestID { get; set; }
		public string ResponseCode { get; set; }
		public string ResponseDescription { get; set; }
		public string CustomerMessage { get; set; }
	}
}
