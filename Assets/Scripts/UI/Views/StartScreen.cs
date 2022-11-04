using Modules;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Views
{
    public class StartScreen : BaseScreen
    {
        [SerializeField] private Button startButton;
        private IGameStateSwitcher _gameStateSwitcher;

        [Inject]
        public void Construct(IGameStateSwitcher gameStateSwitcher)
        {
            _gameStateSwitcher = gameStateSwitcher;
            startButton.OnClickAsObservable()
                .Subscribe(StartGame)
                .AddTo(this);
        }

        private void StartGame(Unit _)
        {
            _gameStateSwitcher.ChangeState(EGameState.Start);
            base.Hide();
        }
    }
}