using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace LIMSInfrastructure.Services.Messaging
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
        MessageResource SendSms(string number, string message);
    }
}
