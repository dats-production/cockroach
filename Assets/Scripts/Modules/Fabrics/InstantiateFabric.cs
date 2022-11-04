using DataBases;
using Models;
using UnityEngine;
using Views;
using Zenject;

namespace Modules.Fabrics
{
    public interface IInstantiateFabric<in TModel, out TObject>
    {
        TObject Instantiate(TModel model);
    }
    
    public class InstantiateFabric: IInstantiateFabric<GameObjectModel, ILinkable>
    {
        private readonly DiContainer _container;
        private readonly IPrefabsBase _prefabsBase;

        public InstantiateFabric(DiContainer container, IPrefabsBase prefabsBase)
        {
            _container = container;
            _prefabsBase = prefabsBase;
        }
        
        public ILinkable Instantiate(GameObjectModel model)
        {
            var prefab = _prefabsBase.Get(model.Name);
            
            var go = _container.InstantiatePrefab(prefab, model.StartTransform.position, Quaternion.identity, null);
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