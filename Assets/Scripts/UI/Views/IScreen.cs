namespace UI.Views
{
    public interface IScreen
    {
        bool IsShown { get; }
        void Show();
        void Hide();
    }
}