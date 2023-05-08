using Abp.AspNetCore.Mvc.Authorization;
using Abp.AspNetZeroCore.Net;
using Abp.Extensions;
using Abp.IO.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using tmss.Authorization;
using tmss.MultiTenancy;
using tmss.Storage;
using tmss.Web.Helpers;

namespace tmss.Web.Controllers
{
    [AbpMvcAuthorize]
    public class TenantCustomizationController : tmssControllerBase
    {
        private readonly TenantManager _tenantManager;

        public TenantCustomizationController(
            TenantManager tenantManager)
        {
            _tenantManager = tenantManager;
        }


    }
}
