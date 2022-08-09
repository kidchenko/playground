public record class WeatherForecastViewModel
{
    public WeatherForecastViewModel(WeatherForecast model)
    {
        Date = model.Date;
        TemperatureC = model.TemperatureC.value;
        TemperatureF = model.TemperatureF.value;
    }

    public DateTimeOffset Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF { get; set; }

    public string? Summary { get; set; }
}
