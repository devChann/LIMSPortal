using MpesaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSWebApp.ViewModels.MpesaModels
{
    public class LipaNaMpesaItem
    {
        public LipaNaMpesaOnline lipaonline = new LipaNaMpesaOnline
        {
            AccountReference = "account",
            Amount = "1",
            PartyA = "254708374149",
            PartyB = "174379",
            BusinessShortCode = "174379",
            CallBackURL = "https://demo.osl.co.ke:7575/lims/api/callback",
            Password = "MTc0Mzc5YmZiMjc5ZjlhYTliZGJjZjE1OGU5N2RkNzFhNDY3Y2QyZTBjODkzMDU5YjEwZjc4ZTZiNzJhZGExZWQyYzkxOTIwMTgwNzA1MTI0MjMy",
            PhoneNumber = "254708374149",
            Timestamp = "20180705124232", //DateTime.Now.ToString("yyyyMMddHHmmss"),
            TransactionDesc = "test"
        };
    }
}
