using Models;
using UI;
using UI.Views;
using UnityEngine;
using Utils;
using Views;
using Zenject;

namespace Services
{
    public class GameStartModule
    {
        private ISpawnModule<ObjectModel, Transform, ILinkable> _spawnModule;
        
        [Inject]
        public void Construct(ISpawnModule<ObjectModel, Transform, ILinkable> spawnModule,
            DiContainer diContainer, GetPointFromScene getPointFromScene, UIManager uiManager, StartScreen startScreen)
        {
            uiManager.OpenScreen(startScreen);
            var startPointModel = diContainer.Instantiate<CheckPointModel>();
            startPointModel.Name = "CheckPoint";
            startPointModel.Type.Value = CheckPointType.Start;
            var startPointTransform = getPointFromScene.GetPoint("Start");
            spawnModule.Spawn(startPointModel, startPointTransform);
            
            var finishPointModel = diContainer.Instantiate<CheckPointModel>();
            finishPointModel.Name = "CheckPoint";
            finishPointModel.Type.Value = CheckPointType.Finish;
            var finishPointTransform = getPointFromScene.GetPoint("Finish");
            spawnModule.Spawn(finishPointModel, finishPointTransform);

            for (var i = 0; i < 2; i++)
            {
                var cockroachModel = diContainer.Instantiate<CockroachModel>();
                cockroachModel.Name = "Cockroach";
                spawnModule.Spawn(cockroachModel, startPointTransform);
            }
        }
    }
}