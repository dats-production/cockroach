using UI.Views;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Models
{
    public class GameOverScreen : BaseScreen
    {
        [SerializeField] private Button restartButton;
        
        [Inject]
        public void Construct()
        {
            restartButton.OnClickAsObservable().Subscribe(x => Debug.Log(111111)).AddTo(this);
        }
    }
}