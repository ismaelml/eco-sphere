using EcoSphere.Domain;

namespace EcoSphere.UseCases
{
    public class GrowPlantUseCase
    {
        private readonly Plant _plant;
        private readonly Climate _climate;

        public GrowPlantUseCase(Plant plant, Climate climate)
        {
            _plant = plant;
            _climate = climate;
        }

        public void Tick(float deltaTime)
        {
            if (_climate.CurrentWeather == WeatherType.Sunny)
                _plant.AccumulateGrowth(deltaTime * 1f);
            else if (_climate.CurrentWeather == WeatherType.Rainy)
                _plant.AccumulateGrowth(deltaTime * 0.75f);
        }

        public PlantStage GetCurrentStage()
        {
            return _plant.Stage;
        }

        public float GetGrowth()
        {
            return _plant.Growth;
        }
    }
}