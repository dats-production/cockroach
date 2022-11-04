using Configs.Settings;
using Modules;
using UniRx;
using UnityEngine;
using Zenject;

namespace Views
{
    public class TriggerZoneView : LinkableView
    {
        private IPlayerInputModule _playerInputModule;
        private IPauseModule _pauseModule;
        private IGameSettings _gameSettings;

        [Inject]
        public void Construct(IGameSettings gameSettings, IPlayerInputModule playerInputModule, IPauseModule pauseModule)
        {
            _gameSettings = gameSettings;
            _pauseModule = pauseModule;
            _playerInputModule = playerInputModule;
            gameSettings.TriggerDistance.Subscribe(SetTriggerZoneRadius).AddTo(this);
        }

        private void Update()
        {
            transform.position = _playerInputModule.MousePosition;
        }

        private void SetTriggerZoneRadius(float radius)
        {
            var diameter = radius * 1.5f;
            transform.localScale = new Vector3(diameter, transform.localScale.y, diameter);
        }
    }
}
