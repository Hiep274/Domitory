using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using tmss.Web.Helpers;

namespace tmss.Web.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var defaultApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(Path.Combine(Directory.GetCurrentDirectory(), "key.json")),
            });

            CurrentDirectoryHelpers.SetCurrentDirectory();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return new WebHostBuilder()
                .UseKestrel(opt => opt.AddServerHeader = false)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIIS()
                .UseIISIntegration()
                .UseStartup<Startup>();
        }
    }
}
