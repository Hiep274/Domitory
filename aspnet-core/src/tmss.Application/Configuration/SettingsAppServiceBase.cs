using Abp.Net.Mail;
using System.Threading.Tasks;

namespace tmss.Configuration
{
    public abstract class SettingsAppServiceBase : tmssAppServiceBase
    {
        private readonly IEmailSender _emailSender;

        protected SettingsAppServiceBase(
            IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

       
    }
}
