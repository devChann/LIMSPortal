﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LIMS.Infrastructure.Services.Payment.Mpesa
{
	public class LNMOQueryResponse
	{
		public string ResponseCode { get; set; }
		public string ResponseDescription { get; set; }
		public string MerchantRequestID { get; set; }
		public string CheckoutRequestID { get; set; }
		public string ResultCode { get; set; }
		public string ResultDesc { get; set; }
	}
}
