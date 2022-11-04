using UnityEngine;
using Zenject;

namespace Modules
{
    public class ScreenBorderDetectorModule
    {
        public float HorizontalBorder;
        public float VerticalBorder;
        
        [Inject]
        public void Construct()
        {
            var borders = Camera.main.ScreenToWorldPoint(
                new Vector3(Screen.width, Screen.height, Camera.main.transform.position.y));
            HorizontalBorder = borders.x;
            VerticalBorder = borders.z;
        }
    }
}
