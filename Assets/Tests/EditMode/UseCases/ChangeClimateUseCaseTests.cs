using NUnit.Framework;
using EcoSphere.Domain;
using EcoSphere.UseCases;

namespace EcoSphere.Tests.UseCases
{
    public class ChangeClimateUseCaseTests
    {
        [Test]
        public void Execute_ShouldChangeWeather()
        {
            var climate = new Climate(WeatherType.Sunny);
            var useCase = new ChangeClimateUseCase(climate);

            useCase.Execute(WeatherType.Rainy);

            Assert.AreEqual(WeatherType.Rainy, climate.CurrentWeather);
        }

        [Test]
        public void Execute_ShouldAllowMultipleWeatherChanges()
        {
            var climate = new Climate(WeatherType.Cloudy);
            var useCase = new ChangeClimateUseCase(climate);

            useCase.Execute(WeatherType.Rainy);
            Assert.AreEqual(WeatherType.Rainy, climate.CurrentWeather);

            useCase.Execute(WeatherType.Sunny);
            Assert.AreEqual(WeatherType.Sunny, climate.CurrentWeather);
        }
    }
}