using Abp.Web.Models;
using Castle.Core.Logging;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using tmss.Configuration;

namespace tmss.Web.Controllers
{
    public class FbLeadController : tmssControllerBase
    {
        readonly ILogger _logger;

        public FbLeadController(
            ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Verification Requests
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="challenge"></param>
        /// <param name="verify_token"></param>
        /// <returns>hub.challenge</returns>
        [HttpGet]
        [DontWrapResult]
        public string WebHook(
            [FromQuery(Name = "hub.mode")] string mode,
            [FromQuery(Name = "hub.challenge")] string challenge,
            [FromQuery(Name = "hub.verify_token")] string verify_token)
        {
            if (mode != "subscribe") return string.Empty;

            var verifyCode = SettingManager.GetSettingValue(AppSettings.FbLead.VerifyToken);
            return verifyCode == verify_token ? challenge : string.Empty;
        }

        /// <summary>
        /// Nhận thông báo
        /// </summary>
        /// <param name="payload"></param>
      
    }
}
