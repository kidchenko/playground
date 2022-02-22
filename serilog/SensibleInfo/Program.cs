using Serilog;
using Masking.Serilog;

var user = new User("kidchenko", "P@ssw0rd");

// See https://aka.ms/new-console-template for more information
Log.Logger = new LoggerConfiguration()
    .Destructure.ByMaskingProperties("Password", "Token")
    // .Enrich.With(new ThreadIdEnricher())
    // .WriteTo.Console(new RenderedCompactJsonFormatter())
    // .WriteTo.Console(new CompactJsonFormatter())
	.WriteTo.Console()
    // .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Information("Ah, there you are!");
Log.Information("My user is {@User}", user);

Console.WriteLine("Hello, World!");

class User
{
    public User(string name, string password)
    {
        Name = name;
        Password = password;
    }
    public string Name { get; set; }

    public string Password { get; set; }
}
