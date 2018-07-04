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
            AccountReference = "ref",
            Amount = "1",
            PartyA = "254708374149",
            PartyB = "174379",
            BusinessShortCode = "174379",
            CallBackURL = "http://mockbin.org/bin/7e613f32-e00a-48d3-86e4-9088e4f96ffa",
            Password = "MTc0Mzc5YmZiMjc5ZjlhYTliZGJjZjE1OGU5N2RkNzFhNDY3Y2QyZTBjODkzMDU5YjEwZjc4ZTZiNzJhZGExZWQyYzkxOTIwMTgwNzAzMTc1MTA4",
            PhoneNumber = "254708374149",
            Timestamp = DateTime.Now.ToString("yyyyMMddHHmmss"), // new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(),
            TransactionDesc = "test"
        };
    }
}
