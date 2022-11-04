using UniRx;

namespace Configs.Settings
{
    public interface IGameSettings
    {
        IReactiveProperty<float> CockroachSpeed { get; set; }
        IReactiveProperty<float> CockroachAccelerationSpeed { get; set; }
        IReactiveProperty<float> TriggerDistance { get; set; }
    }
    public class GameSettings : IGameSettings
    {
        public IReactiveProperty<float> CockroachSpeed { get; set; } = new ReactiveProperty<float>();
        public IReactiveProperty<float> CockroachAccelerationSpeed { get; set; } = new ReactiveProperty<float>();
        public IReactiveProperty<float> TriggerDistance { get; set; } = new ReactiveProperty<float>();
    }
}