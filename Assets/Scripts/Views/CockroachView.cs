using System;
using Configs;
using Models;
using Modules;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Views;
using Zenject;
using Random = UnityEngine.Random;

public class CockroachView : LinkableView
{
    [SerializeField] private NavMeshAgent agent;

    private IPlayerInputModule _playerInputModule;
    private IGameConfig _gameConfig;
    private CockroachModel _cockroachModel;
    private float _triggetDistance;
    private ScreenBorderDetectorModule _screenBorderDetectorModule;

    [Inject]
    public void Construct(IPlayerInputModule playerInputModule, 
        IGameConfig gameConfig, ScreenBorderDetectorModule screenBorderDetectorModule)
    {
        _screenBorderDetectorModule = screenBorderDetectorModule;
        _gameConfig = gameConfig;
        _playerInputModule = playerInputModule;
    }

    public override void Link(ObjectModel model)
    {
        _cockroachModel = model as CockroachModel;
    }

    private void Update()
    {
        _cockroachModel.SetCockroachState(transform.position);
        switch (_cockroachModel.CockroachState)
        {
            case ECockroachState.Running:
                agent.destination = _cockroachModel.FinishPoint.position;
                agent.speed = _cockroachModel.BaseSpeed;
                //agent.speed = _cockroachModel.BaseSpeed * _accelerationMultiplier;
                // _accelerationMultiplier += Time.deltaTime/_cockroachModel.AccelerationTime;
                // if (Math.Abs(agent.speed - _cockroachModel.BaseSpeed) < 0.01f)
                //     _accelerationMultiplier = 1;
                break;
            case ECockroachState.Escaping:
                agent.acceleration = _gameConfig.CockroachConfig.chasingAcceleration;
                agent.destination = GetSafePosition();
                agent.speed = _cockroachModel.AccelerationSpeed;
                //_accelerationMultiplier = 0;
                // agent.speed = _cockroachModel.BaseSpeed + _cockroachModel.AccelerationSpeed * _accelerationMultiplier;
                // _accelerationMultiplier += Time.deltaTime/_cockroachModel.AccelerationTime;
                // if (Math.Abs(agent.speed - _cockroachModel.BaseSpeed) < 0.01f)
                //     _accelerationMultiplier = 1;
                break;
            default:
                Debug.LogError($"There is no cockroach state: {_cockroachModel.CockroachState}");
                break;
        }
    }
    
    private Vector3 GetSafePosition()
    {
        var cockroachPos = Transform.position;
        var mousePos = _playerInputModule.MousePosition;
        var safePosition = (cockroachPos - mousePos).normalized * (_gameConfig.CockroachConfig.safeDistance);
        if (safePosition.x > _screenBorderDetectorModule.HorizontalBorder
            && safePosition.x < -_screenBorderDetectorModule.HorizontalBorder
            && safePosition.y > _screenBorderDetectorModule.VerticalBorder
            && safePosition.y < -_screenBorderDetectorModule.VerticalBorder)
        {
            GetSafePosition();
        }
        return safePosition;
    }
}

