namespace Models
{
    public interface ICheckPointModel
    {
    }
    
    public class StartCheckPointModel : GameObjectModel, ICheckPointModel
    {
    }
    
    public class FinishCheckPointModel : GameObjectModel, ICheckPointModel
    {
    }
}