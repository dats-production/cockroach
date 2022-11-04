using Models;
using UI;
using UI.Views;
using UnityEngine;
using Zenject;

namespace Modules
{
    public interface IGameStateSwitcher
    {
        EGameState CurrentState { get; }
        void ChangeState(EGameState state);
    }
    
    public class GameStateSwitcher : IGameStateSwitcher
    {
        private IPauseModule _pauseModule;
        private GameOverScreen _gameOverScreen;
        private UIManager _uiManager;
        private IClearModule<CockroachModel> _clearModule;
        private CockroachModel _cockroachModel;
        private IGameStartModule _gameStartModule;
        private SettingsScreen _settingsScreen;

        public EGameState CurrentState { get; private set; }

        [Inject]
        public void Construct(IPauseModule pauseModule, UIManager uiManager, 
            GameOverScreen gameOverScreen, IClearModule<CockroachModel> clearModule,
            CockroachModel cockroachModel, IGameStartModule gameStartModule,
            SettingsScreen settingsScreen)
        {
            _settingsScreen = settingsScreen;
            _gameStartModule = gameStartModule;
            _cockroachModel = cockroachModel;
            _clearModule = clearModule;
            _uiManager = uiManager;
            _gameOverScreen = gameOverScreen;
            _pauseModule = pauseModule;
        }

        public void ChangeState(EGameState state)
        {
            CurrentState = state;
            
            switch (state)
            {
                case EGameState.Start:
                    _pauseModule.UnPause();
                    _uiManager.OpenScreen(_settingsScreen);
                    break;
                case EGameState.Paused:
                    _pauseModule.Pause();
                    break;
                case EGameState.GameOver:
                    _uiManager.OpenScreen(_gameOverScreen);
                    _uiManager.HideScreen(_settingsScreen);
                    _pauseModule.Pause();
                    break;
                case EGameState.Restart:
                    _clearModule.ClearView(_cockroachModel);
                    _gameStartModule.RestartCockroachModel();
                    ChangeState(EGameState.Start);
                    break;
                default:
                    Debug.LogError($"There is no game state: {state}");
                    break;
            }
        }
    }

    public enum EGameState
    {
        Start,
        Paused,
        GameOver,
        Restart
    }
}