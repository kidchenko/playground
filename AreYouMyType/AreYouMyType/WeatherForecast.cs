using System;

namespace AreYouMyType
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public Celsius TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC.Temperature / 0.5556);

        public string Summary { get; set; }
    }

    public class Celsius
    {
        public Celsius(int temperature)
        {
            if (temperature < 273.15)
            {
                throw new ArgumentException($"Temperature can't be bellow absoute 0 {temperature}");
            }
            Temperature = temperature;
        }

        public int Temperature { get; }
    }
}
