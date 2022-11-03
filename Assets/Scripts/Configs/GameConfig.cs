using UnityEngine;

namespace Configs
{
    public interface IGameConfig
    {
        PlayerConfig PlayerConfig { get; }
        CockroachConfig CockroachConfig { get; }
    }
    
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Settings/GameConfig", order = 0)]
    public class GameConfig: ScriptableObject, IGameConfig
    {
        [SerializeField] private PlayerConfig playerConfig;     
        [SerializeField] private CockroachConfig cockroachConfig;    

        public PlayerConfig PlayerConfig => playerConfig;
        public CockroachConfig CockroachConfig => cockroachConfig;
    }
}