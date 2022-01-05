using Serilog;

using var log = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

log.Information("Hello, Serilog!");

// log levels

log.Information("INFORMATION");
log.Error("ERROR");
log.Verbose("VERBOSE");

// static access

Log.Logger = log;
Log.Information("The global logger has been configured");

// end of app
Console.WriteLine("Hello, World!");
