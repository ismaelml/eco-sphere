using EcoSphere.Domain;

namespace EcoSphere.UseCases
{
    public class GrowPlantUseCase
    {
        private readonly Plant _plant;
        private readonly Climate _climate;
        
        private const float SunnyGrowthRate = 1f;
        private const float RainyGrowthRate = 0.75f;

        public GrowPlantUseCase(Plant plant, Climate climate)
        {
            _plant = plant;
            _climate = climate;
        }

        public void Tick(float deltaTime)
        {
            if (_climate.CurrentWeather == WeatherType.Sunny)
                _plant.AccumulateGrowth(deltaTime * SunnyGrowthRate);
            else if (_climate.CurrentWeather == WeatherType.Rainy)
                _plant.AccumulateGrowth(deltaTime * RainyGrowthRate);
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