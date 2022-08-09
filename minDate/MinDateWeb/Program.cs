using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MinDateWeb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");


            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(GetBaseUrl(builder)) });

            await builder.Build().RunAsync();
        }

        public static string GetBaseUrl(WebAssemblyHostBuilder builder)
        {
            return "http://localhost:5050";
            // if (builder.HostEnvironment.IsDevelopment())
            // {
            //     return "http://localhost:5050";
            // }
            //
            // return "https://mindateapp.azurewebsites.net/";
        }
    }
}
