using UnityEngine;

namespace Modules
{
    public interface IPlayerInputModule
    {
        Vector3 MousePosition { get; }
    }

    public class PlayerInputModule : MonoBehaviour, IPlayerInputModule
    {
        [SerializeField] private Camera _camera;
        private LayerMask _groundLayerMask;
        
        public Vector3 MousePosition { get; private set; }
    
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
                MousePosition = raycastHit.point;
            }
        }
    }
}