using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;

namespace NetFiveSimple.AuthHandler
{
    public static class ConfigurationJwtOption// : IConfigureNamedOptions<JwtBearerOptions>
    {
        //public void Configure(string name, JwtBearerOptions options)
        //{
        //    if (name == "Bearer") 
        //    {
        //        Configure(options);
        //    }
        //    //if (name == "WeatherAuth") 
        //    //{
        //    //    ConfigureJwtForWeatherContoller(options);
        //    //}
        //}

        public static void Configure(JwtBearerOptions options)
        {
            options.Authority = "https://securetoken.google.com/my-firebase-project";
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "my-firebase-project",
                ValidateAudience = true,
                ValidAudience = "my-firebase-project",
                ValidateLifetime = true
            };
        }

        public static void ConfigureFirebase(JwtBearerOptions options)
        {
            options.Authority = "https://securetoken.google.com/my-firebase-project";
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "my-firebase-project",
                ValidateAudience = true,
                ValidAudience = "my-firebase-project",
                ValidateLifetime = true
            };
        }

        //public void ConfigureJwtForWeatherContoller(JwtBearerOptions options) 
        //{ 

        //}
    }
}
