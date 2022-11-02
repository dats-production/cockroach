using UniRx;
using UnityEngine;

namespace Input
{
    public interface IPlayerInput
    {
        IReactiveProperty<Vector3> MousePosition { get; set; }
    }

    public class PlayerInput : MonoBehaviour, IPlayerInput
    {
        [SerializeField] private Camera _camera;
        private LayerMask _groundLayerMask;
        public IReactiveProperty<Vector3> MousePosition { get; set; } = new ReactiveProperty<Vector3>();
    
        private void Start()
        {
            var groundLayerIndex = LayerMask.NameToLayer("Ground");
            _groundLayerMask = (1 << groundLayerIndex);
        }

        private void Update()
        {
            var ray = _camera.ScreenPointToRay(UnityEngine.Input.mousePosition);
            if (Physics.Raycast(ray, out var raycastHit, float.MaxValue, _groundLayerMask))
            {
                MousePosition.Value = raycastHit.point;
            }
        }
    }
}