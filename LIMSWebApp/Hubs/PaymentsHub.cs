using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSWebApp.Hubs
{
    public class PaymentsHub: Hub
    {
        public async Task UpdatePaymentList(string user, string message)
        {
            var userx = Context.User?.Identity.Name ?? "Anonymous";

            await Clients.All.SendAsync("ReceiveMessage", userx, message);
        }
    }
}
