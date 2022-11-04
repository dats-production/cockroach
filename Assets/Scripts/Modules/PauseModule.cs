using UniRx;
using UnityEngine;

namespace Modules
{
    public interface IPauseModule
    {
        void Pause();
        void UnPause();
        IReactiveProperty<bool> IsPaused { get; set; }
    }

    public class PauseModule : IPauseModule
    {
        public IReactiveProperty<bool> IsPaused { get; set; } = new ReactiveProperty<bool>();

        public void Pause()
        {
            Time.timeScale = 0;
            IsPaused.Value = true;
        }

        public void UnPause()
        {
            Time.timeScale = 1;
            IsPaused.Value = false;
        }
    }
}