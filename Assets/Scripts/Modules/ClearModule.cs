using Models;

namespace Modules
{
    public interface IClearModule<in TModel>  
        where TModel : GameObjectModel
    {
        void ClearView(TModel model);
    }
    
    public class ClearModule<TModel> : IClearModule<TModel>
        where TModel : GameObjectModel
    {
        public void ClearView(TModel model)
        {
            foreach (var view in model.Views)
            {
                view.Destroy();
            }
            model.Views.Clear();
        }
    }
}