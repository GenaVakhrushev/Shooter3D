using UnityEngine;
using UnityEngine.Serialization;

namespace Shooter.Settings
{
    [CreateAssetMenu(fileName = nameof(GameConfigSO), menuName = nameof(GameConfigSO), order = 0)]
    public class GameConfigSO : ScriptableObject
    {
        public GameConfig gameConfig;
    }
}