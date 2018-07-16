using MpesaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSWebApp.ViewModels.MpesaModels
{
    public class MpesaItems
    {
        public LipaNaMpesaOnline lipaonline = new LipaNaMpesaOnline
        {
            AccountReference = "ref",
            Amount = "1",
            PartyA = "254708374149",
            PartyB = "174379",
            BusinessShortCode = "174379",
            CallBackURL = "https://demo.osl.co.ke:7575/lims/api/callback",
            Password = "MTc0Mzc5YmZiMjc5ZjlhYTliZGJjZjE1OGU5N2RkNzFhNDY3Y2QyZTBjODkzMDU5YjEwZjc4ZTZiNzJhZGExZWQyYzkxOTIwMTgwNzE2MTI0OTE2",
            PhoneNumber = "254708374149",
            Timestamp = "20180716124916",//DateTime.Now.ToString("yyyyMMddHHmmss"),
            TransactionDesc = "test"
            //TransactionType = "CustomerPayBillOnline"
        };

        public CustomerToBusinessRegister c2bregisterUrl = new CustomerToBusinessRegister
        {
            ResponseType = "Cancelled",
            ShortCode = "600157",
            ConfirmationURL = "https://demo.osl.co.ke:7575/lims/api/callback",
            ValidationURL = "https://demo.osl.co.ke:7575/lims/api/callback",

        };

        public CustomerToBusinessSimulate c2b = new CustomerToBusinessSimulate
        {
            ShortCode = "600157",
            Amount = "1",
            BillRefNumber = "account",
            Msisdn = "254708374149"
        };
    }
}
