using Configs.Settings;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Views
{
    public class SettingsScreen : BaseScreen
    {
        [SerializeField] private Slider cockroachSpeedSlider;
        [SerializeField] private Slider cockroachAccelerationSlider;
        [SerializeField] private Slider triggerRadiusSlider;
        
        private IGameSettings _gameSettings;

        [Inject]
        public void Construct(IGameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            cockroachSpeedSlider.OnValueChangedAsObservable().Subscribe(SetCockroachSpeed);
            cockroachAccelerationSlider.OnValueChangedAsObservable().Subscribe(SetCockroachAcceleration);
            triggerRadiusSlider.OnValueChangedAsObservable().Subscribe(SetTriggerRadius);
        }

        private void SetCockroachSpeed(float value) =>
            _gameSettings.CockroachSpeed.Value = value;

        private void SetCockroachAcceleration(float value) =>
            _gameSettings.CockroachAccelerationSpeed.Value = value;

        private void SetTriggerRadius(float value) =>
            _gameSettings.TriggerDistance.Value = value;
        
    }
}