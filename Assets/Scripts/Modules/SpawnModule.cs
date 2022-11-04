using Models;
using Modules.Fabrics;
using Views;
using Zenject;

namespace Modules
{
    public interface ISpawnModule<in TModel>
    {
        void Spawn(TModel model);
    }
    
    public class SpawnModule: ISpawnModule<GameObjectModel>
    {
        private IInstantiateFabric<GameObjectModel, ILinkable> _instantiateFabric;

        [Inject]
        public void Construct(IInstantiateFabric<GameObjectModel, ILinkable> instantiateFabric)
        {
            _instantiateFabric = instantiateFabric;
        }
        
        public void Spawn(GameObjectModel model)
        {
            var linkable = _instantiateFabric.Instantiate(model);
            linkable?.Link(model);
            model.Views.Add(linkable);
        }
    }
}