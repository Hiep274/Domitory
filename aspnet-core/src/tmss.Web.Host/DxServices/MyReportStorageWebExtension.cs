using DevExpress.XtraReports.UI;
using tmss.Web.DxServices.Reports;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using tmss.Web.DxServices.DataHandler;
using DevExpress.DataAccess.Json;
using tmss.Web.Controllers;

namespace tmss.Web.DxServices
{
    /// <summary>
    /// Added By Vaibhav Patil
    /// </summary>
    public class MyReportStorageWebExtension : DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension
    {
        public override bool IsValidUrl(string url)
        {
            // Determines whether or not the URL passed to the current Report Storage is valid. 
            // For instance, implement your own logic to prohibit URLs that contain white spaces or some other special characters. 
            // This method is called before the CanSetData and GetData methods.

            //All URLs will be valid as not the same name as index.
            return true;
        }

        public override byte[] GetData(string url)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                switch (url)
                {
                    case "AUDITLOG":
                        XtraReport report = new AuditLogRpt();

                        string repJsonP = JsonConvert.SerializeObject(
                                                    ReportDataHandlerBase.GetAuditLogMaster());

                        ((DevExpress.DataAccess.Json.CustomJsonSource)((DevExpress.DataAccess.Json.JsonDataSource)report.DataSource).JsonSource).Json = repJsonP;
                        report.DataMember = null;

                        report.SaveLayoutToXml(ms);
                        break;
                    case "AUDITLOG1":
                        XtraReport demoAuditReort = new DemoAuditReport();

                        string repJsonSource = JsonConvert.SerializeObject(ReportDataHandlerBase.GetAuditLogMaster());

                        var jsonDataSource = new JsonDataSource();

                        // Specify the object that retrieves JSON data.
                        jsonDataSource.JsonSource = new CustomJsonSource(repJsonSource);

                        demoAuditReort.DataSource = jsonDataSource;
                        demoAuditReort.DataMember = null;

                        demoAuditReort.SaveLayoutToXml(ms);
                        break;
                   
                    default:
                        XtraReport chartReport = new DemoChartReport();
                        chartReport.SaveLayoutToXml(ms);
                        break;
                }
                return ms.ToArray();
            }
        }

        public override Dictionary<string, string> GetUrls()
        {
            return new Dictionary<string, string>() {
                {"AUDITLOG", "AUDITLOG" }
            };
        }

        public override void SetData(DevExpress.XtraReports.UI.XtraReport report, string url)
        {
            base.SetData(report, url);
        }

        public override string SetNewData(DevExpress.XtraReports.UI.XtraReport report, string defaultUrl)
        {
            return base.SetNewData(report, defaultUrl);
        }
    }
}