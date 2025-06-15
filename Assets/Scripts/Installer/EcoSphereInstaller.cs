using EcoSphere.Domain;
using EcoSphere.UseCases;
using EcoSphere.UI;
using EcoSphere.Infrastructure;
using Zenject;

public class EcoSphereInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Climate>().AsSingle().WithArguments(WeatherType.Sunny);
        Container.Bind<Plant>().AsSingle();
        
        Container.Bind<PlantUI>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlantUpdater>().FromComponentInHierarchy().AsSingle();
        
        Container.Bind<ChangeClimateUseCase>().AsSingle();
        Container.Bind<GrowPlantUseCase>().AsSingle();
    }
}
