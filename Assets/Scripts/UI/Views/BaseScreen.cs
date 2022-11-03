using UnityEngine;

namespace UI.Views
{
    public abstract class BaseScreen: MonoBehaviour, IScreen
    {
        public bool IsShown { get; private set; }

        public virtual void Show()
        {
            gameObject.SetActive(true);
            IsShown = true;
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
            IsShown = false;
        }
    }
}