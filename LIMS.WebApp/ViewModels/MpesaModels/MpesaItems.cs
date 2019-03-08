using MpesaLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIMS.WebApp.ViewModels.MpesaModels
{
    public class MpesaItems
    {
        public LipaNaMpesaOnlineDto lipaonline = new LipaNaMpesaOnlineDto
        {
            AccountReference = "ref",
            Amount = "1",
            PartyA = "254708374149",
            PartyB = "174379",
            BusinessShortCode = "174379",
            CallBackURL = "https://demo.osl.co.ke:7575/lims/api/callback",
            Password = "MTc0Mzc5YmZiMjc5ZjlhYTliZGJjZjE1OGU5N2RkNzFhNDY3Y2QyZTBjODkzMDU5YjEwZjc4ZTZiNzJhZGExZWQyYzkxOTIwMTgwNzE2MTI0OTE2",
            //Password = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(PartyB + Passkey + Timestamp)),    
            PhoneNumber = "254725589166", //254708374149
            Timestamp = "20180716124916",//DateTime.Now.ToString("yyyyMMddHHmmss"),
            TransactionDesc = "test"
            //TransactionType = "CustomerPayBillOnline"
        };

        public CustomerToBusinessRegisterUrlDto c2bregisterUrl = new CustomerToBusinessRegisterUrlDto
        {
            ResponseType = "Cancelled",
            ShortCode = "600157",
            ConfirmationURL = "https://demo.osl.co.ke:7574/api/callback",
            ValidationURL = "https://demo.osl.co.ke:7574/api/callback",
        };

        public CustomerToBusinessSimulateDto c2b = new CustomerToBusinessSimulateDto
        {
            ShortCode = "600157",
            Amount = "1",
            BillRefNumber = "account",
            Msisdn = "254708374149"
        };
    }
}
