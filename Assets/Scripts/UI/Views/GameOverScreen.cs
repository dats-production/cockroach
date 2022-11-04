using Modules;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Views
{
    public class GameOverScreen : BaseScreen
    {
        [SerializeField] private Button restartButton;
        
        private IGameStateSwitcher _gameStateSwitcher;

        [Inject]
        public void Construct(IGameStateSwitcher gameStateSwitcher)
        {
            _gameStateSwitcher = gameStateSwitcher;
            restartButton.OnClickAsObservable().Subscribe(RestartGame).AddTo(this);
        }

        private void RestartGame(Unit _)
        {
            _gameStateSwitcher.ChangeState(EGameState.Restart);
            base.Hide();
        }
    }
}