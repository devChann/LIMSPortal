using System;
using System.Collections.Generic;
using System.Text;

namespace LIMSInfrastructure.Services.Payment.Mpesa
{
	public class MpesaNumberFormatter
	{
		public static string FormatPhoneNumber(string phonenumber)
		{
			var formattedstring = string.Empty;
			var sFirstCharacter = phonenumber.Substring(0, 1);
			//check if number begins with +
			if (sFirstCharacter == "+")
			{
				formattedstring = phonenumber.Substring(1);
			}
			else
			{
				formattedstring = phonenumber;
			}

			//check if number begins with +254
			//check if number begins with 07
			//check for number that beigns with 7

			return formattedstring;
		}
	}
}
