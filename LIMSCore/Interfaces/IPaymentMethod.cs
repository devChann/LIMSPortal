using System;
using System.Collections.Generic;
using System.Text;

namespace LIMSCore.Interfaces
{
	public interface IPaymentMethod
	{
		void PayWithMPesa();
		void PayWithCard();
		void PayWithAirtel();
	}
}
