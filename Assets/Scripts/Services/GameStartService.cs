using Models;
using UnityEngine;
using Utils;
using Views;
using Zenject;

namespace Services
{
    public class GameStartService
    {
        private ISpawnService<GameModel, Transform, ILinkable> _spawnService;
        
        [Inject]
        public void Construct(ISpawnService<GameModel, Transform, ILinkable> spawnService,
            DiContainer diContainer, GetPointFromScene getPointFromScene)
        {
            var startPointModel = diContainer.Instantiate<CheckPointModel>();
            startPointModel.Name = "CheckPoint";
            startPointModel.Type.Value = CheckPointType.Start;
            var startPointTransform = getPointFromScene.GetPoint("Start");
            spawnService.Spawn(startPointModel, startPointTransform);
            
            var finishPointModel = diContainer.Instantiate<CheckPointModel>();
            finishPointModel.Name = "CheckPoint";
            finishPointModel.Type.Value = CheckPointType.Finish;
            var finishPointTransform = getPointFromScene.GetPoint("Finish");
            spawnService.Spawn(finishPointModel, finishPointTransform);

            var cockroachModel = diContainer.Instantiate<CockroachModel>();
            cockroachModel.Name = "Cockroach";
            var cockroachTransform = getPointFromScene.GetPoint(cockroachModel.Name);
            spawnService.Spawn(cockroachModel, cockroachTransform);
        }
    }
}