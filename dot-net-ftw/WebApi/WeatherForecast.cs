public record class WeatherForecast
{
    public DateTimeOffset Date { get; set; }

    public Temperature? TemperatureC { get; set; }

    public Temperature TemperatureF => new Temperature("F", 32 + (int)(TemperatureC.value / 0.5556)) ;

    public string? Summary { get; set; }
}


public record Temperature(string scale, int value);
