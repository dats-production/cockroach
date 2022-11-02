using System;
using Models;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Views;

public class CockroachView : LinkableView
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _finishPos;

    public override void Link(GameModel model)
    {
        var cockroachModel = model as CockroachModel;
        cockroachModel.CockroachState.Subscribe(SetMovement).AddTo(this);
    }

    private void SetMovement(ECockroachState cockroachState)
    {
        switch (cockroachState)
        {
            case ECockroachState.Running:
                _agent.destination = _finishPos.position;
                break;
            case ECockroachState.Escaping:
                break;
            case ECockroachState.Fleeing:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(cockroachState), cockroachState, null);
        }
    }
}

