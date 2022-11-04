using Configs.Settings;
using Modules;
using UniRx;
using UnityEngine;
using Utils;
using Zenject;

namespace Models
{
    public interface ICockroachModel
    {
        IReactiveProperty<ECockroachState>  CockroachState { get; set;}
        Transform FinishPoint { get; }
        float BaseSpeed { get; }
        float AccelerationSpeed { get; }
    }
    
    public class CockroachModel : GameObjectModel, ICockroachModel
    {
        private IPlayerInputModule _playerInputModule;
        private float _triggetDistance;
        private FinishCheckPointModel _finishCheckPointModel;
        private IGameStateSwitcher _gameStateSwitcher;

        public IReactiveProperty<ECockroachState> CockroachState { get; set; } =
            new ReactiveProperty<ECockroachState>();
        public Transform FinishPoint { get; private set; }
        public float BaseSpeed { get; private set; }
        public float AccelerationSpeed { get; private set; }

        [Inject]
        public void Construct(IPlayerInputModule playerInputModule, GetPointFromScene getPointFromScene,
            FinishCheckPointModel finishCheckPointModel, IGameStateSwitcher gameStateSwitcher,
            IGameSettings gameSettings)
        {
            _gameStateSwitcher = gameStateSwitcher;
            _finishCheckPointModel = finishCheckPointModel;
            _playerInputModule = playerInputModule;
            FinishPoint = getPointFromScene.GetPoint("Finish");

            gameSettings.CockroachSpeed.Subscribe((x) => BaseSpeed = x);
            gameSettings.CockroachAccelerationSpeed.Subscribe((x) => AccelerationSpeed = x);
            gameSettings.TriggerDistance.Subscribe((x) => _triggetDistance = x);
        }

        public void SetCockroachState(Vector3 cockroachPosition)
        {
            if(_gameStateSwitcher?.CurrentState != EGameState.Start) return;
            
            var distance = Vector3.Distance(cockroachPosition, _playerInputModule.MousePosition);

            CockroachState.Value = distance > _triggetDistance 
                ? ECockroachState.Running 
                : ECockroachState.Escaping;
        }
        
        public void CheckDistanceToFinish(Vector3 cockroachPosition)
        {
            if(_gameStateSwitcher?.CurrentState != EGameState.Start) return;
            
            var distance = Vector3.Distance(
                cockroachPosition, _finishCheckPointModel.StartTransform.position);
            
            if(distance < 1)
                _gameStateSwitcher.ChangeState(EGameState.GameOver);;
        }
    }
}

public enum ECockroachState
{
    Running,
    Escaping
}