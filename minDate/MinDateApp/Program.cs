using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TimeZoneConverter;
using MinDate.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

await using var app = builder.Build();
app.UseCors();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

RequestDelegate getNowHandler = async (context) =>
{
    var containsTimezone = ContainsHeader(context, "tz");
    var response = !containsTimezone ?
        GetResponseForCommonTimeZones() :
        GetResponseForSpecificTimeZones(context);

    await context.Response.WriteAsJsonAsync(response);
};

RequestDelegate helloDelegate = async (context) =>
{
    var response = new
    {
        Message = "Hello World",
        Endpoints = new
        {
            Now = "/api/now",
            TimeZones = "/api/timezones"
        }
    };

    await context.Response.WriteAsJsonAsync(response);
};

RequestDelegate getTimeZonesDelegate = async (context) =>
{
    var containSearch = ContainsHeader(context, "q");
    var response = !containSearch ?
        GetAllTimeZoneResponses() :
        FilterTimeZoneResponses(context);

    await context.Response.WriteAsJsonAsync(response);
};



bool ContainsHeader(HttpContext httpContext, string key)
{
    return httpContext.Request.Query.ContainsKey(key);
}

IEnumerable<NowResponse> GetResponseForSpecificTimeZones(HttpContext httpContext)
{
    var utcNow = DateTimeOffset.UtcNow;
    var tzQuery = httpContext.Request.Query["tz"].ToString();

    var tzQueryValues = tzQuery.Split(",", StringSplitOptions.TrimEntries);

    var responses = tzQueryValues.Select(term =>
    {
        var searchedTimeZone = TimeZoneInfo.FindSystemTimeZoneById(term);
        var specificTimeZone = new NowResponse(searchedTimeZone, utcNow)
        {

        };
        return specificTimeZone;
    }).ToList();

    responses.Insert(0, new LocalNowResponse(utcNow));
    responses.Insert(1, new UtcNowResponse(utcNow));
    return responses;
}

IEnumerable<NowResponse> GetResponseForCommonTimeZones()
{
    var utcNow = DateTimeOffset.UtcNow;
    var commonTimeZones = new[]
        {"Asia/Bangkok", "Asia/Singapore", "Australia/Melbourne", "Asia/Shanghai", "Africa/Johannesburg"};

    var commonTimeZoneResponses = commonTimeZones
        .Select(tz => TZConvert.GetTimeZoneInfo(tz))
        .Select(tz => new NowResponse(tz, utcNow));

    var nowResponses = new List<NowResponse>
    {
        new LocalNowResponse(utcNow),
        new UtcNowResponse(utcNow)
    };

    return commonTimeZoneResponses.Concat(nowResponses);
}

IEnumerable<TimeZoneResponse> GetAllTimeZoneResponses()
{
    var timeZoneInfos = TimeZoneInfo.GetSystemTimeZones();

    return timeZoneInfos.Select(tz => new TimeZoneResponse(tz));
}

IEnumerable<TimeZoneResponse> FilterTimeZoneResponses(HttpContext httpContext)
{
    var timeZoneInfos = TimeZoneInfo.GetSystemTimeZones();
    var searchTerm = httpContext.Request.Query["q"].ToString();

    return timeZoneInfos
        .Where(tz => tz.Id.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase) ||
                                tz.DisplayName.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase))
        .Select(tz => new TimeZoneResponse(tz));
}

app.MapGet("/", helloDelegate);

app.MapGet("/api/now", getNowHandler);

app.MapGet("/api/timezones", getTimeZonesDelegate);

await app.RunAsync("http://localhost:5050");
