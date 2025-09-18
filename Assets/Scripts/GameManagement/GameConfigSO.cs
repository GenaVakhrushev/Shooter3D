using AYellowpaper.SerializedCollections;
using Shooter.Enemies.Core;
using Shooter.Enemies.Spawn;
using Shooter.HP;
using Shooter.Items.Core;
using Shooter.Player.Stats;
using UnityEngine;

namespace Shooter.GameManagement
{
    [CreateAssetMenu(fileName = nameof(GameConfigSO), menuName = nameof(GameConfigSO), order = 0)]
    public class GameConfigSO : ScriptableObject
    {
        [Header("Player settings")]
        public float PlayerMoveSpeed;
        public float PlayerRotationSpeed;
        public HPModel PlayerHPModel;
        public int PlayerAvailableSkillPoints;
        public SerializedDictionary<StatName, StatModel> StatModels;
        public ItemConfig PlayerItemConfig;
        
        [Header("Enemies settings")]
        public SpawnParameters EnemiesSpawnParameters;
        public EnemyConfig[] EnemyConfigs;
    }
}