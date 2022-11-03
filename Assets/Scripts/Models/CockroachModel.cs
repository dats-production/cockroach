using System;
using System.Threading;
using Configs;
using Cysharp.Threading.Tasks;
using Modules;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using Utils;
using Zenject;

namespace Models
{
    public interface ICockroachModel
    {
        ECockroachState CockroachState { get; set;}
        Transform FinishPoint { get; set;}
        float BaseSpeed { get; set;}
        float AccelerationSpeed { get; set;}
        public float AccelerationTime { get; set; }

    }
    public class CockroachModel : ObjectModel, ICockroachModel
    {
        private IPlayerInputModule _playerInputModule;
        private IGameConfig _gameConfig;
        
        private float _sqrTriggetDistance;
        
        public ECockroachState CockroachState { get; set;}
        public Transform FinishPoint { get; set; }
        public float BaseSpeed { get; set; }
        public float AccelerationSpeed { get; set; }
        public float AccelerationTime { get; set; }

        [Inject]
        public void Construct(IPlayerInputModule playerInputModule, IGameConfig gameConfig,
            GetPointFromScene getPointFromScene)
        {
            _gameConfig = gameConfig;
            _playerInputModule = playerInputModule;
            FinishPoint = getPointFromScene.GetPoint("Finish");
            BaseSpeed = gameConfig.CockroachConfig.baseSpeed;
            AccelerationSpeed = gameConfig.CockroachConfig.accelerationSpeed;
            AccelerationTime = gameConfig.CockroachConfig.accelerationTime;
            _sqrTriggetDistance = _gameConfig.PlayerConfig.triggetDistance;
        }

        public void SetCockroachState(Vector3 cockroachPosition)
        { 
            var sqrDistance = Vector3.Distance(cockroachPosition, _playerInputModule.MousePosition);

            CockroachState = sqrDistance > _sqrTriggetDistance 
                ? ECockroachState.Running 
                : ECockroachState.Escaping;
        }
    }
}

public enum ECockroachState
{
    Running,
    Escaping
}