using System.IO;
using System.Linq;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Auditing;
using Abp.Domain.Repositories;
using DevExpress.DataAccess.Json;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using tmss.Authorization;
using tmss.Web.DxServices.Reports;

namespace tmss.Web.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class DemoController : tmssControllerBase
    {
        private readonly IRepository<AuditLog, long> _auditLogRepository;

        public DemoController(IRepository<AuditLog, long> auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        [HttpGet("[action]")]
        public ActionResult Export(string format = "pdf")
        {
            format = format.ToLower();
            XtraReport report = new DemoAuditReport();
            //string repJsonP = JsonConvert.SerializeObject(ReportDataHandlerBase.GetAuditLogMaster());

            string repJsonP = JsonConvert.SerializeObject(_auditLogRepository.GetAll().Take(20).ToList());

            var jsonDataSource = new JsonDataSource();

            // Specify the object that retrieves JSON data.
            jsonDataSource.JsonSource = new CustomJsonSource(repJsonP);

            report.DataSource = jsonDataSource;
            report.DataMember = null;

            string contentType = string.Format("application/{0}", format);
            using (MemoryStream ms = new MemoryStream())
            {
                ExportFileType(report, format, ms, contentType);
                return File(ms.ToArray(), contentType);
            }

        }



        public void ExportFileType(XtraReport reports, string format, MemoryStream ms, string contentType)
        {
           
            switch (format)
            {
                case "pdf":
                    contentType = "application/pdf";
                    reports.ExportToPdf(ms);
                    break;
                case "docx":
                    // Umcomment the snippet code to export Doc file that user cannot modify exported file
                    /* contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    report.ExportToDocx(ms);
                    */

                    // Using DocxExportOptions to export Origional Microsoft Word to allow users can modify after exporting
                    DocxExportOptions DocxExportOptions = new DocxExportOptions()
                    {
                        ExportMode = DocxExportMode.SingleFile,
                        TableLayout = true
                    };
                    reports.ExportToDocx(ms, DocxExportOptions);
                    break;
                case "xls":
                    contentType = "application/vnd.ms-excel";
                    reports.ExportToXls(ms);
                    break;
                case "xlsx":
                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    reports.ExportToXlsx(ms);
                    break;
                case "rtf":
                    reports.ExportToRtf(ms);
                    break;
                case "mht":
                    contentType = "message/rfc822";
                    reports.ExportToMht(ms);
                    break;
                case "html":
                    contentType = "text/html";
                    reports.ExportToHtml(ms);
                    break;
                case "txt":
                    contentType = "text/plain";
                    reports.ExportToText(ms);
                    break;
                case "csv":
                    contentType = "text/plain";
                    reports.ExportToCsv(ms);
                    break;
                case "png":
                    contentType = "image/png";
                    reports.ExportToImage(ms, new ImageExportOptions() { Format = System.Drawing.Imaging.ImageFormat.Png });
                    break;
            }
        }
    }
}