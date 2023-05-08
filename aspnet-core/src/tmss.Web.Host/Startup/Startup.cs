using Abp.AspNetCore;
using Abp.AspNetCore.Mvc.Antiforgery;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.AspNetZeroCore.Web.Authentication.JwtBearer;
using Abp.Castle.Logging.Log4Net;
using Abp.Extensions;
using Abp.Hangfire;
using Abp.PlugIns;
using Castle.Facilities.Logging;
using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Hangfire;
using HealthChecks.UI.Client;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Owl.reCAPTCHA;
using Stripe;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using tmss.Authorization;
using tmss.Configuration;
using tmss.Configure;
using tmss.EntityFrameworkCore;
using tmss.Identity;
using tmss.Schemas;
using tmss.Web.Authentication.JwtBearer;
using tmss.Web.Chat.SignalR;
using tmss.Web.Common;
using tmss.Web.HealthCheck;
using tmss.Web.IdentityServer;
using tmss.Web.Swagger;
using HealthChecksUISettings = HealthChecks.UI.Configuration.Settings;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;

namespace tmss.Web.Startup
{
    public class Startup
    {
        private const string DefaultCorsPolicyName = "localhost";

        private readonly IConfigurationRoot _appConfiguration;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Startup(IWebHostEnvironment env)
        {
            _hostingEnvironment = env;
            _appConfiguration = env.GetAppConfiguration();
        }
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //MVC
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            // Demo Devexpress line 62 Start up
            services.AddDevExpressControls();
            ///services.AddDevExpressControls(settings => settings.Resources = ResourcesType.ThirdParty | ResourcesType.DevExtreme);
            DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(new MyReportStorageWebExtension());

            services.AddTransient<WebDocumentViewerController>();
            services.AddMvc().ConfigureApplicationPartManager(x =>
            {
                var parts = x.ApplicationParts;
                var aspNetCoreReportingAssemblyName = typeof(WebDocumentViewerController).Assembly.GetName().Name;
                var reportingPart = parts.FirstOrDefault(part => part.Name == aspNetCoreReportingAssemblyName);
                if (reportingPart != null)
                {
                    parts.Remove(reportingPart);
                }
            });

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AbpAutoValidateAntiforgeryTokenAttribute());
            }).AddNewtonsoftJson();
            //services.AddTransient<IFCMNotificationJob, FCMNotificationJob>();
            services.AddSignalR(options => { options.EnableDetailedErrors = true; });

            //Configure CORS for angular2 UI
            services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    //App:CorsOrigins in appsettings.json can contain more than one address with splitted by comma.
                    builder
                              .WithOrigins(
                                  // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                                  _appConfiguration["App:CorsOrigins"]
                                      .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(o => o.RemovePostFix("/"))
                                      .ToArray()
                              )
                              .SetIsOriginAllowedToAllowWildcardSubdomains()
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials();
                });
            });

            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

            //Identity server
            if (bool.Parse(_appConfiguration["IdentityServer:IsEnabled"]))
            {
                IdentityServerRegistrar.Register(services, _appConfiguration, options =>
                     options.UserInteraction = new UserInteractionOptions()
                     {
                         LoginUrl = "/UI/Login",
                         LogoutUrl = "/UI/LogOut",
                         ErrorUrl = "/Error"
                     });
            }

            if (WebConsts.SwaggerUiEnabled)
            {
                //Swagger - Enable this line and the related lines in Configure method to enable swagger UI
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo() { Title = "TMV Marketing API", Version = "v1" });
                    //options.DocInclusionPredicate((docName, description) => true);
                    options.DocInclusionPredicate((docName, description) =>
                            {
                                if (!description.TryGetMethodInfo(out MethodInfo methodInfo)) return false;
                                // Exclude all DevExpress reporting controllers
                                return !methodInfo.DeclaringType.AssemblyQualifiedName.StartsWith("DevExpress", StringComparison.OrdinalIgnoreCase);
                            });
                    options.ParameterFilter<SwaggerEnumParameterFilter>();
                    options.SchemaFilter<SwaggerEnumSchemaFilter>();
                    options.OperationFilter<SwaggerOperationIdFilter>();
                    options.OperationFilter<SwaggerOperationFilter>();
                    options.CustomDefaultSchemaIdSelector();
                }).AddSwaggerGenNewtonsoftSupport();
            }

            //Recaptcha
            services.AddreCAPTCHAV3(x =>
            {
                x.SiteKey = _appConfiguration["Recaptcha:SiteKey"];
                x.SiteSecret = _appConfiguration["Recaptcha:SecretKey"];
            });

            if (WebConsts.HangfireDashboardEnabled)
            {
                //Hangfire(Enable to use Hangfire instead of default job manager)
                services.AddHangfire(config =>
                {
                    config.UseSqlServerStorage(_appConfiguration.GetConnectionString("Default"));
                }); services.AddHangfireServer();
            }

            if (WebConsts.GraphQL.Enabled)
            {
                services.AddAndConfigureGraphQL();
            }

            if (bool.Parse(_appConfiguration["HealthChecks:HealthChecksEnabled"]))
            {
                services.AddAbpZeroHealthCheck();

                //Identity server
                if (bool.Parse(_appConfiguration["IdentityServer:IsEnabled"]))
                {
                    IdentityServerRegistrar.Register(services, _appConfiguration, options =>
                         options.UserInteraction = new UserInteractionOptions()
                         {
                             LoginUrl = "/UI/Login",
                             LogoutUrl = "/UI/LogOut",
                             ErrorUrl = "/Error"
                         });
                }

                if (WebConsts.SwaggerUiEnabled)
                {
                    //Swagger - Enable this line and the related lines in Configure method to enable swagger UI
                    services.AddSwaggerGen(options =>
                    {
                        options.SwaggerDoc("v1", new OpenApiInfo() { Title = "TMV Marketing API", Version = "v1" });
                        options.DocInclusionPredicate((docName, description) => true);
                        //options.DocInclusionPredicate((docName, description) => true); -- line 128
                        options.DocInclusionPredicate((docName, description) =>
                            {
                                if (!description.TryGetMethodInfo(out MethodInfo methodInfo)) return false;
                                // Exclude all DevExpress reporting controllers
                                return !methodInfo.DeclaringType.AssemblyQualifiedName.StartsWith("DevExpress", StringComparison.OrdinalIgnoreCase);
                            });
                        options.ParameterFilter<SwaggerEnumParameterFilter>();
                        options.SchemaFilter<SwaggerEnumSchemaFilter>();
                        options.OperationFilter<SwaggerOperationIdFilter>();
                        options.OperationFilter<SwaggerOperationFilter>();
                        options.CustomDefaultSchemaIdSelector();
                    }).AddSwaggerGenNewtonsoftSupport();
                }

                //Recaptcha
                services.AddreCAPTCHAV3(x =>
                {
                    x.SiteKey = _appConfiguration["Recaptcha:SiteKey"];
                    x.SiteSecret = _appConfiguration["Recaptcha:SecretKey"];
                });


                var healthCheckUISection = _appConfiguration.GetSection("HealthChecks")?.GetSection("HealthChecksUI");

                if (bool.Parse(healthCheckUISection["HealthChecksUIEnabled"]))
                {
                    services.Configure<HealthChecksUISettings>(settings =>
                    {
                        healthCheckUISection.Bind(settings, c => c.BindNonPublicProperties = true);
                    });
                    services.AddHealthChecksUI();
                }
            }

            //Configure Abp and Dependency Injection
            return services.AddAbp<tmssWebHostModule>(options =>
            {
                //Configure Log4Net logging
                options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig(_hostingEnvironment.IsDevelopment()
                            ? "log4net.config"
                            : "log4net.Production.config")
                );

                options.PlugInSources.AddFolder(Path.Combine(_hostingEnvironment.WebRootPath, "Plugins"), SearchOption.AllDirectories);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //Initializes ABP framework.
            app.UseAbp(options =>
            {
                options.UseAbpRequestLocalization = false; //used below: UseAbpRequestLocalization
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("~/Error?statusCode={0}");
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            // app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(DefaultCorsPolicyName); //Enable CORS!
                                                // DevExpress -- line 217
            app.UseDevExpressControls();
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();
           // app.UseMiddleware<tmssJwtSecurityTokenMiddlewareHandler>();

            if (bool.Parse(_appConfiguration["IdentityServer:IsEnabled"]))
            {
                app.UseJwtTokenMiddleware("IdentityBearer");
                app.UseIdentityServer();
            }

            app.UseAuthorization();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                if (scope.ServiceProvider.GetService<DatabaseCheckHelper>().Exist(_appConfiguration["ConnectionStrings:Default"]))
                {
                    app.UseAbpRequestLocalization();
                }
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("~/Error?statusCode={0}");
                app.UseExceptionHandler("/Error");
            }


            if (WebConsts.HangfireDashboardEnabled)
            {
                //Hangfire dashboard &server(Enable to use Hangfire instead of default job manager)
                app.UseHangfireDashboard(WebConsts.HangfireDashboardEndPoint, new DashboardOptions
                {
                    Authorization = new[] { new AbpHangfireAuthorizationFilter(AppPermissions.Pages_Administration_HangfireDashboard) }
                });
                //app.UseHangfireServer();
            }

            if (bool.Parse(_appConfiguration["Payment:Stripe:IsActive"]))
            {
                StripeConfiguration.ApiKey = _appConfiguration["Payment:Stripe:SecretKey"];
            }

            if (WebConsts.GraphQL.Enabled)
            {
                app.UseGraphQL<MainSchema>();
                if (WebConsts.GraphQL.PlaygroundEnabled)
                {
                    app.UseGraphQLPlayground(
                        new GraphQLPlaygroundOptions()); //to explorer API navigate https://*DOMAIN*/ui/playground
                }
            }

            app.UseEndpoints(endpoints =>
            {
                //Hieu comment to test
                endpoints.MapHub<AbpCommonHub>("/signalr");
                //endpoints.MapHub<ChatHub>("/signalr-chat");

                endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

                if (bool.Parse(_appConfiguration["HealthChecks:HealthChecksEnabled"]))
                {
                    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                    {
                        Predicate = _ => true,
                        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                    });
                }
            });

            if (bool.Parse(_appConfiguration["HealthChecks:HealthChecksEnabled"]))
            {
                if (bool.Parse(_appConfiguration["HealthChecks:HealthChecksUI:HealthChecksUIEnabled"]))
                {
                    app.UseHealthChecksUI();
                }
            }

            if (WebConsts.SwaggerUiEnabled)
            {
                // Enable middleware to serve generated Swagger as a JSON endpoint
                app.UseSwagger();
                // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(_appConfiguration["App:SwaggerEndPoint"], "TMV Marketing API V1");
                    options.IndexStream = () => Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream("tmss.Web.wwwroot.swagger.ui.index.html");
                    options.InjectBaseUrl(_appConfiguration["App:ServerRootAddress"]);
                }); //URL: /swagger
            }

            //User upload file
            /*  app.UseHttpsRedirection();
              app.UseStaticFiles(new StaticFileOptions()
              {
                 FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                  RequestPath = new PathString("/Resources")
              });
            */

        }
    }
}
