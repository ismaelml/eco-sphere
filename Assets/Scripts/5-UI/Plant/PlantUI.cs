using UnityEngine;
using TMPro;
using EcoSphere.Domain;
using EcoSphere.UseCases;
using Zenject;

namespace EcoSphere.UI
{
    public class PlantUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI plantStageText;

        [Inject] private GrowPlantUseCase _growPlantUseCase;

        public void UpdatePlantUI()
        {
            PlantStage stage = _growPlantUseCase.GetCurrentStage();
            plantStageText.text = $"Plant Stage: {stage}";
        }
    }
}