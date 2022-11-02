using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Input;
using UniRx;
using UnityEngine;
using Zenject;

namespace Models
{
    public interface ICockroachModel
    {
        IReactiveProperty<ECockroachState> CockroachState { get; set;}
    }
    public class CockroachModel : GameModel, ICockroachModel
    {
        private IPlayerInput _playerInput;
        private readonly float _safeSqrDistance = 1;
        //private CancellationTokenSource _cancellationTokenSource;
        private float _delay = 2;
        
        public IReactiveProperty<ECockroachState> CockroachState { get; set;} = 
            new ReactiveProperty<ECockroachState>();

        [Inject]
        public void Construct(IPlayerInput playerInput)
        {
            playerInput.MousePosition.Subscribe(SetCockroachState);
        }
        
        private void SetCockroachState(Vector3 mousePosition)
        {
            if(View == null) return;
            
            var sqrDistance = (View.Transform.position - mousePosition).magnitude;
            if (sqrDistance > _safeSqrDistance)
            {
                CockroachState.Value = ECockroachState.Running;
            }
            else
            {
                //_cancellationTokenSource.Cancel();
                //_cancellationTokenSource = new CancellationTokenSource();
                CockroachState.Value = ECockroachState.Escaping;
                //DelayForEscaping(_cancellationTokenSource.Token).Forget();
            }
        }
        
        // private async UniTask DelayForEscaping(CancellationToken token)
        // {
        //     token.ThrowIfCancellationRequested();
        //     await UniTask.Delay(TimeSpan.FromSeconds(_delay), false, 
        //         PlayerLoopTiming.PostLateUpdate, token);
        //
        //     CockroachState.Value = ECockroachState.Fleeing;
        // }
    }
}

public enum ECockroachState
{
    Running,
    Escaping,
    Fleeing
}