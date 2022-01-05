using Serilog;

Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

Log.Information("Hello, world!");

int a = 10, b = 0;
var request = new { number1 = 10, number2 = 0 };
try
{
    Log.Debug("Dividing {A} by {B}", a, b);
    Log.Debug("Dividing {@A} by {@B}", a, b);
    Log.Debug("Division Request {request}", request);
    Log.Debug("Division Request {@request}", request);
    Console.WriteLine(a / b);
}
catch (Exception ex)
{
    Log.Error(ex, "Something went wrong");
}
finally
{
    Log.CloseAndFlush();
}
