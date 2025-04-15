using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Diagnostics;
using System.Net.Http.Formatting;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace Concessionaria.Api.Infra.Configuration
{
    public static class WebApiConfig
    {
        public static void Register(this HttpConfiguration config, IDependencyResolver dependencyResolver)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("Ping", "", new { controller = "Ping", action = "Get" });
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}", new { controller = "Ping", action = RouteParameter.Optional });

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new DefaultContractResolver
                    {
                        IgnoreSerializableAttribute = true
                    }
                }
            });

            config.DependencyResolver = dependencyResolver;


            new Thread(() =>
            {
                while (true)
                {
                    var memoryUsage = 0D;
                    try
                    {
                        using (var process = Process.GetCurrentProcess())
                        {
                            process.Refresh();
                            memoryUsage = Math.Round(process.PrivateMemorySize64 / 1024D / 1024D, 1);
                        }

                        if (memoryUsage < 1)
                            continue;
                    }
                    catch (Exception )
                    {
                        // Log.Write(@"C:\Log\Noc\Momentum", $"Log_{DateTime.Today:yy-MM-dd}", ex.ToString());
                    }

                    Thread.Sleep(TimeSpan.FromMinutes(10));
                }
            }).Start();
        }
    }
}