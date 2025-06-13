using EcoSphere.Domain;
using EcoSphere.UseCases;
using Zenject;

public class EcoSphereInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Climate>().AsSingle().WithArguments(WeatherType.Sunny);
        
        Container.Bind<ChangeClimateUseCase>().AsSingle();
    }
}
