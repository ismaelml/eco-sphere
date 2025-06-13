using UnityEngine;
using UnityEngine.UI;
using EcoSphere.Domain;
using EcoSphere.UseCases;
using EcoSphere.Interfaces;
using TMPro;
using Zenject;

namespace EcoSphere.UI
{
    public class ClimateUI : MonoBehaviour, IClimatePresenter
    {
        [Header("UI Elements")]
        [SerializeField] private TextMeshProUGUI weatherText;
        [SerializeField] private Button sunnyButton;
        [SerializeField] private Button cloudyButton;
        [SerializeField] private Button rainyButton;

        [Inject] private ChangeClimateUseCase _changeClimateUseCase;
        
        [Inject] private Climate _climate;

        private void Start()
        {
            sunnyButton.onClick.AddListener(() => OnWeatherButtonClicked(WeatherType.Sunny));
            rainyButton.onClick.AddListener(() => OnWeatherButtonClicked(WeatherType.Rainy));
            cloudyButton.onClick.AddListener(() => OnWeatherButtonClicked(WeatherType.Cloudy));

            DisplayWeather(_climate.CurrentWeather);
        }

        private void OnWeatherButtonClicked(WeatherType weatherType)
        {
            _changeClimateUseCase.Execute(weatherType);
            DisplayWeather(weatherType);
        }

        public void DisplayWeather(WeatherType weather)
        {
            weatherText.text = $"Weather: {weather}";
        }
    }
}
