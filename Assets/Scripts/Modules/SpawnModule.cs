using DataBases;
using Models;
using UnityEngine;
using Views;
using Zenject;

namespace Services
{
    public interface ISpawnModule<in TModel, in TTransform, out TObject>
    {
        TObject Spawn(TModel model, TTransform transform);
    }
    
    public class SpawnModule: ISpawnModule<ObjectModel, Transform, ILinkable>
    {
        private readonly DiContainer _container;
        private readonly IPrefabsBase _prefabsBase;

        public SpawnModule(DiContainer container, IPrefabsBase prefabsBase)
        {
            _container = container;
            _prefabsBase = prefabsBase;
        }
        
        public ILinkable Spawn(ObjectModel model, Transform transform)
        {
            var prefab = _prefabsBase.Get(model.Name);
            
            var go = _container.InstantiatePrefab(prefab, transform.position, Quaternion.identity, null);
            var components = go.GetComponents<ILinkable>();
            Debug.Assert(components.Length == 1,$"Object view must have only one ILinkable component!!" +
                                                $" Description : {go.name} " );
            var linkable = go.GetComponent<ILinkable>();
            linkable?.Link(model);
            model.View = linkable;
            return linkable;
        }
    }
}