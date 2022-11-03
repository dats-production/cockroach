using UI.Models;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Views
{
    public class StartScreen : BaseScreen
    {
        [SerializeField] private Button startButton;
        
        [Inject]
        public void Construct()
        {
            startButton.OnClickAsObservable().Subscribe(x => Debug.Log(111111)).AddTo(this);
        }
    }
}