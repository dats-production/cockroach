using Configs;
using Modules;
using UnityEngine;
using Zenject;

namespace Views
{
    public class TriggerZoneView : MonoBehaviour
    {
        private IGameConfig _gameConfig;
        private IPlayerInputModule _playerInputModule;

        [Inject]
        public void Construct(IGameConfig gameConfig, IPlayerInputModule playerInputModule)
        {
            _playerInputModule = playerInputModule;
            _gameConfig = gameConfig;
        }

        private void Update()
        {
            var radius = _gameConfig.PlayerConfig.triggetDistance;
            transform.localScale = new Vector3(radius, transform.localScale.y, radius);
            transform.position = _playerInputModule.MousePosition;
        }
    }
}
