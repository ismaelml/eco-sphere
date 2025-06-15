using UnityEngine;
using EcoSphere.UseCases;
using EcoSphere.UI;
using Zenject;

namespace EcoSphere.Infrastructure
{
    public class PlantUpdater : MonoBehaviour
    {
        [Inject] private GrowPlantUseCase _growPlantUseCase;
        [Inject] private PlantUI _plantUI;

        private void Update()
        {
            _growPlantUseCase.Tick(Time.deltaTime);
            _plantUI.UpdatePlantUI();
        }
    }
}