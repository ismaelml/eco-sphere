namespace EcoSphere.Domain
{
    public enum WeatherType
    {
        Sunny,
        Cloudy,
        Rainy
    }

    public class Climate
    {
        public WeatherType CurrentWeather { get; private set; }

        public Climate(WeatherType initialWeather)
        {
            CurrentWeather = initialWeather;
        }

        public void ChangeWeather(WeatherType newWeather)
        {
            CurrentWeather = newWeather;
        }
    }
}
