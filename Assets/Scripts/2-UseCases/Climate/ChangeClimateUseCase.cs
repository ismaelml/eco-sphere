using EcoSphere.Domain;

namespace EcoSphere.UseCases
{
    public class ChangeClimateUseCase
    {
        private readonly Climate _climate;

        public ChangeClimateUseCase(Climate climate)
        {
            _climate = climate;
        }

        public void Execute(WeatherType newWeather)
        {
            _climate.ChangeWeather(newWeather);
        }
    }
}