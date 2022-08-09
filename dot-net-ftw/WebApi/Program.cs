var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var test1 = new WeatherForecast();
var test2 = new WeatherForecast();



var result1 = test1.Equals(test2);
var result2 = test1 == test2;
Console.WriteLine(test1.GetHashCode());
Console.WriteLine(result1);


// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

// app.Run();



