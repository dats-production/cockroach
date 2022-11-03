using Configs;
using DataBases;
using Modules;
using Services;
using UnityEngine;
using Utils;
using Zenject;

namespace Installers
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private GetPointFromScene getPointFromScene;
        [SerializeField] private PlayerInputModule playerInputModule;
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private PrefabsBase prefabBase;
        
        public override void InstallBindings()
        {
            Container.Bind<GetPointFromScene>().FromInstance(getPointFromScene).AsSingle();
            Container.Bind<ScreenBorderDetectorModule>().AsSingle().NonLazy();
            Container.BindInterfacesTo<PlayerInputModule>().FromInstance(playerInputModule).AsSingle();
            Container.BindInterfacesTo<GameConfig>().FromInstance(gameConfig).AsSingle();
            Container.BindInterfacesTo<PrefabsBase>().FromInstance(prefabBase).AsSingle();
            Container.BindInterfacesTo<SpawnModule>().AsSingle();
            Container.Bind<GameStartModule>().AsSingle().NonLazy();
        }
    }
}