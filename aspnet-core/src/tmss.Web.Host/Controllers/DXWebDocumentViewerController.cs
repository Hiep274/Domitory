
﻿using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer.Native.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace tmss.Web.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("DemoReport")]
    public class DXWebDocumentViewerController : WebDocumentViewerController
    {
        public DXWebDocumentViewerController(IWebDocumentViewerMvcControllerService controllerService) : base(controllerService) { }
        public override Task<IActionResult> Invoke()
        {
            //Request.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return base.Invoke();
        }
    }
}

