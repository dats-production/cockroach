using Configs;
using Configs.Settings;
using Models;
using Modules;
using UnityEngine;
using UnityEngine.AI;
using Views;
using Zenject;

public class CockroachView : LinkableView
{
    [SerializeField] private NavMeshAgent agent;

    private IPlayerInputModule _playerInputModule;
    private CockroachModel _cockroachModel;
    private float _triggetDistance;
    private ScreenBorderDetectorModule _screenBorderDetectorModule;
    private IGameSettings _gameSettings;

    [Inject]
    public void Construct(IPlayerInputModule playerInputModule, IGameSettings gameSettings,
        ScreenBorderDetectorModule screenBorderDetectorModule)
    {
        _screenBorderDetectorModule = screenBorderDetectorModule;
        _playerInputModule = playerInputModule;
        _gameSettings = gameSettings;
    }

    public override void Link(GameObjectModel model)
    {
        _cockroachModel = model as CockroachModel;
    }

    private void Update()
    {
        if(_cockroachModel == null) return;
        _cockroachModel.SetCockroachState(transform.position);
        _cockroachModel.CheckDistanceToFinish(transform.position);
        SwitchState(_cockroachModel.CockroachState.Value);
    }

    private void SwitchState(ECockroachState state)
    {
        switch (state)
        {
            case ECockroachState.Running:
                agent.acceleration = 8;
                agent.destination = _cockroachModel.FinishPoint.position;
                agent.speed = _cockroachModel.BaseSpeed;
                //agent.speed = _cockroachModel.BaseSpeed * _accelerationMultiplier;
                // _accelerationMultiplier += Time.deltaTime/_cockroachModel.AccelerationTime;
                // if (Math.Abs(agent.speed - _cockroachModel.BaseSpeed) < 0.01f)
                //     _accelerationMultiplier = 1;
                break;
            case ECockroachState.Escaping:
                agent.acceleration = _cockroachModel.AccelerationSpeed;
                agent.destination = GetSafePosition();
                agent.speed = _cockroachModel.AccelerationSpeed;
                //_accelerationMultiplier = 0;
                // agent.speed = _cockroachModel.BaseSpeed + _cockroachModel.AccelerationSpeed * _accelerationMultiplier;
                // _accelerationMultiplier += Time.deltaTime/_cockroachModel.AccelerationTime;
                // if (Math.Abs(agent.speed - _cockroachModel.BaseSpeed) < 0.01f)
                //     _accelerationMultiplier = 1;
                break;
            default:
                Debug.LogError($"There is no cockroach state: {state}");
                break;
        }
    }
    private Vector3 GetSafePosition()
    {
        var cockroachPos = agent.transform.position;
        var mousePos = _playerInputModule.MousePosition;

        var safePosition = (cockroachPos - mousePos).normalized + cockroachPos;

        if (safePosition.x > _screenBorderDetectorModule.HorizontalBorder
            || safePosition.x < -_screenBorderDetectorModule.HorizontalBorder
            || safePosition.z > _screenBorderDetectorModule.VerticalBorder
            || safePosition.z < -_screenBorderDetectorModule.VerticalBorder)
        {
            return Vector3.zero;
        };
        return safePosition;
    }
}

