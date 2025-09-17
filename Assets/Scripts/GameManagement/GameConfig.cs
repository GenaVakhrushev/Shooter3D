using Shooter.Enemies.Core;
using Shooter.Enemies.Spawn;
using Shooter.Player;

namespace Shooter.GameManagement
{
    public class GameConfig
    {
        public PlayerModel PlayerModel;
        public SpawnParameters EnemiesSpawnParameters;
        public EnemyConfig[] EnemyConfigs;
    }
}