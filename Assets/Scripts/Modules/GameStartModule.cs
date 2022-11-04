using Models;
using UI;
using UI.Views;
using Utils;
using Zenject;

namespace Modules
{
    public interface IGameStartModule
    {
        void RestartCockroachModel();
    }
    public class GameStartModule : IGameStartModule
    {
        private ISpawnModule<GameObjectModel> _spawnModule;
        private GetPointFromScene _getPointFromScene;
        private CockroachModel _cockroachModel;
        private StartCheckPointModel _startPointModel;
        private FinishCheckPointModel _finishPointModel;
        private TriggerZoneModel _triggerZoneModel;
        
        private readonly int _cockroachViewCount = 2;

        [Inject]
        public void Construct(ISpawnModule<GameObjectModel> spawnModule,
            DiContainer diContainer, GetPointFromScene getPointFromScene, 
            UIManager uiManager, StartScreen startScreen, IGameStateSwitcher gameStateSwitcher, 
            CockroachModel cockroachModel, StartCheckPointModel startPointModel,
            FinishCheckPointModel finishPointModel, TriggerZoneModel triggerZoneModel)
        {
            _triggerZoneModel = triggerZoneModel;
            _finishPointModel = finishPointModel;
            _startPointModel = startPointModel;
            _cockroachModel = cockroachModel;
            _getPointFromScene = getPointFromScene;
            _spawnModule = spawnModule;

            SetModels();
            gameStateSwitcher.ChangeState(EGameState.Paused);
            uiManager.OpenScreen(startScreen);
        }

        public void RestartCockroachModel()
        {
            SetCockroachModels(_cockroachViewCount);
        }

        private void SetModels()
        {
            _startPointModel.Name = "CheckPoint";
            _startPointModel.StartTransform = _getPointFromScene.GetPoint("Start");
            _spawnModule.Spawn(_startPointModel);
            
            _finishPointModel.Name = "CheckPoint";
            _finishPointModel.StartTransform = _getPointFromScene.GetPoint("Finish");
            _spawnModule.Spawn(_finishPointModel);

            SetCockroachModels(_cockroachViewCount);
            
            _triggerZoneModel.Name = "TriggerZone";
            _triggerZoneModel.StartTransform = _getPointFromScene.GetPoint("TriggerZone");
            _spawnModule.Spawn(_triggerZoneModel);
        }

        private void SetCockroachModels(int count)
        {
            for (var i = 0; i < count; i++)
            {
                _cockroachModel.Name = "Cockroach";
                _cockroachModel.StartTransform = _getPointFromScene.GetPoint("Start");
                _spawnModule.Spawn(_cockroachModel);
            }
        }
    }
}