using UI;
using UI.Models;
using UI.Views;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private StartScreen startScreen;
        [SerializeField] private GameOverScreen gameOverScreen;
        
        public override void InstallBindings()
        {
            Container.Bind<UIManager>().FromNew().AsSingle();
            Container.Bind<StartScreen>().FromInstance(startScreen).AsSingle();
            Container.Bind<GameOverScreen>().FromInstance(gameOverScreen).AsSingle();
        }
    }
}