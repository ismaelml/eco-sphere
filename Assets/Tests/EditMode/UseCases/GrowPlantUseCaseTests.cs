// Tests/EditMode/UseCases/GrowPlantUseCaseTests.cs
using NUnit.Framework;
using EcoSphere.Domain;
using EcoSphere.UseCases;

namespace EcoSphere.Tests.UseCases
{
    public class GrowPlantUseCaseTests
    {
        private Plant _plant;
        private Climate _climate;
        private GrowPlantUseCase _useCase;

        [SetUp]
        public void SetUp()
        {
            _plant = new Plant();
            _climate = new Climate(WeatherType.Sunny);
            _useCase = new GrowPlantUseCase(_plant, _climate);
        }

        [Test]
        public void GrowthShouldIncreaseUnderSunnyWeather()
        {
            _useCase.Tick(5f); // sunny → *1f

            Assert.AreEqual(5f, _plant.Growth);
            Assert.AreEqual(PlantStage.Sprout, _plant.Stage);
        }

        [Test]
        public void GrowthShouldIncreaseSlowerUnderRainyWeather()
        {
            _climate.ChangeWeather(WeatherType.Rainy);
            _useCase.Tick(4f); // rainy → *0.75f = 3f

            Assert.AreEqual(3f, _plant.Growth);
            Assert.AreEqual(PlantStage.Seed, _plant.Stage);
        }

        [Test]
        public void ShouldNotGrowUnderCloudyWeather()
        {
            _climate.ChangeWeather(WeatherType.Cloudy);
            _useCase.Tick(10f);

            Assert.AreEqual(0f, _plant.Growth);
            Assert.AreEqual(PlantStage.Seed, _plant.Stage);
        }

        [Test]
        public void ShouldReachMatureStageAtGrowth10()
        {
            _useCase.Tick(10f); // sunny → full growth

            Assert.AreEqual(PlantStage.Mature, _plant.Stage);
            Assert.GreaterOrEqual(_plant.Growth, 10f);
        }
    }
}