using System.Linq;
using Cysharp.Threading.Tasks;
using Modules;
using UniRx;
using Views;
using Zenject;

namespace Models
{
    public class TriggerZoneModel : GameObjectModel
    {
        [Inject]
        public async void Construct(IPauseModule pauseModule)
        {
            await UniTask.DelayFrame(1);
            pauseModule.IsPaused.Subscribe((x) => ToggleView(!x));
        }

        private void ToggleView(bool isActive)
        {
            foreach (var triggerZoneView in Views.Select(view => view  as TriggerZoneView))
            {
                triggerZoneView?.gameObject.SetActive(isActive);
            }
        }
    }
}