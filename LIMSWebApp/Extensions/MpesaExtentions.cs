using Microsoft.Extensions.DependencyInjection;
using MpesaLib.Clients;
using MpesaLib.Interfaces;

namespace LIMSWebApp.Extensions
{
    public static class MpesaExtentions
    {
        public static void AddMpesaSupport(this IServiceCollection services)
        {
            //Add Mpesa Clients
            services.AddHttpClient<IAuthClient, AuthClient>();
            services.AddHttpClient<ILipaNaMpesaOnlineClient, LipaNaMpesaOnlineClient>();          
            services.AddHttpClient<IAccountBalanceQueryClient, AccountBalanceQueryClient>();
            services.AddHttpClient<IC2BClient, C2BClient>();            
            services.AddHttpClient<IB2BClient, B2BClient>();
            services.AddHttpClient<IB2CClient, B2CClient>();
            services.AddHttpClient<IC2BRegisterUrlClient, C2BRegisterUrlClient>();
            services.AddHttpClient<ILipaNaMpesaQueryClient, LipaNaMpesaQueryClient>();
            services.AddHttpClient<ITransactionStatusClient, TransactionStatusClient>();
            services.AddHttpClient<ITransactionReversalClient, TransactionReversalClient>();
        }
    }
}
