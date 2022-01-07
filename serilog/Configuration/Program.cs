// See https://aka.ms/new-console-template for more information

using Configuration;
using Serilog;
using Serilog.Formatting.Compact;

// using Serilog.Formatting.Compact;

Log.Logger = new LoggerConfiguration().CreateLogger();
Log.Information("No one listens to me!");

// Finally, once just before the application exits...
Log.CloseAndFlush();

Console.WriteLine("Hello, World!");

// The example above will create a logger that does not record events anywhere. To see log events, a sink must be configured.

Log.Logger = new LoggerConfiguration()
    .Enrich.With(new ThreadIdEnricher())
    // .WriteTo.Console(new RenderedCompactJsonFormatter())
    // .WriteTo.Console(new CompactJsonFormatter())
	.WriteTo.Console(
        outputTemplate: "{Timestamp:HH:mm} [{Level}] ({ThreadId}) {Message}{NewLine}{Exception}")
    .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Information("Ah, there you are!");
