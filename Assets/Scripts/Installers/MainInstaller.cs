using DataBases;
using Input;
using Models;
using Services;
using UnityEngine;
using Utils;
using Zenject;

namespace Installers
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private GetPointFromScene _getPointFromScene;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private PrefabsBase _prefabBase;
        
        public override void InstallBindings()
        {
            Container.Bind<GetPointFromScene>().FromInstance(_getPointFromScene).AsSingle();
            Container.BindInterfacesTo<PlayerInput>().FromInstance(_playerInput).AsSingle();
            Container.BindInterfacesTo<PrefabsBase>().FromInstance(_prefabBase).AsSingle();
            Container.BindInterfacesTo<SpawnService>().AsSingle();
            Container.Bind<GameStartService>().AsSingle().NonLazy();
        }
    }
}