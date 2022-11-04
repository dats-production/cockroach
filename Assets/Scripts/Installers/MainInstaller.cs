using Configs;
using Configs.Settings;
using DataBases;
using Models;
using Modules;
using Modules.Fabrics;
using UnityEngine;
using Utils;
using Zenject;

namespace Installers
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private GetPointFromScene getPointFromScene;
        [SerializeField] private PlayerInputModule playerInputModule;
        [SerializeField] private PrefabsBase prefabBase;
        
        public override void InstallBindings()
        {
            BindModules();
            BindModels();
        }

        private void BindModules()
        {
            Container.Bind<GetPointFromScene>().FromInstance(getPointFromScene).AsSingle();
            Container.Bind<ScreenBorderDetectorModule>().AsSingle().NonLazy();
            Container.BindInterfacesTo<PlayerInputModule>().FromInstance(playerInputModule).AsSingle();
            Container.BindInterfacesTo<GameSettings>().AsSingle();
            Container.BindInterfacesTo<PrefabsBase>().FromInstance(prefabBase).AsSingle();
            Container.BindInterfacesTo<InstantiateFabric>().AsSingle();
            Container.BindInterfacesTo<SpawnModule>().AsSingle();
            Container.BindInterfacesTo<PauseModule>().AsSingle();
            Container.BindInterfacesTo<GameStateSwitcher>().AsSingle();
            Container.BindInterfacesTo<GameStartModule>().AsSingle().NonLazy();
            Container.BindInterfacesTo<ClearModule<CockroachModel>>().AsSingle();
        }

        private void BindModels()
        {
            Container.BindInterfacesAndSelfTo<CockroachModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartCheckPointModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<FinishCheckPointModel>().AsSingle();
            Container.Bind<TriggerZoneModel>().AsSingle();
        }
    }
}