using Shooter.Enemies.Core;
using Shooter.Enemies.Spawn;
using Shooter.Items.Core;
using Shooter.Player;
using UnityEngine;

namespace Shooter.GameManagement
{
    [CreateAssetMenu(fileName = nameof(GameConfigSO), menuName = nameof(GameConfigSO), order = 0)]
    public class GameConfigSO : ScriptableObject
    {
        public PlayerModel PlayerModel;
        public ItemConfig PlayerItemConfig;
        public SpawnParameters EnemiesSpawnParameters;
        public EnemyConfig[] EnemyConfigs;
    }
}