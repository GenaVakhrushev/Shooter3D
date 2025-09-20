using System.Linq;
using AYellowpaper.SerializedCollections;
using Shooter.Enemies.Core;
using Shooter.Enemies.Spawn;
using Shooter.HP;
using Shooter.Items.Core;
using Shooter.Player;
using Shooter.Player.Stats;
using Shooter.Utils;
using UnityEngine;

namespace Shooter.GameManagement
{
    [CreateAssetMenu(fileName = nameof(GameConfigSO), menuName = nameof(GameConfigSO), order = 0)]
    public class GameConfigSO : ScriptableObject
    {
        [Header("Player settings")]
        public float PlayerMoveSpeed;
        public float PlayerRotationSpeed;
        public float PlayerStartHP;
        public float PlayerBaseMaxHP;
        public int PlayerAvailableSkillPoints;
        public SerializedDictionary<StatName, StatModel> StatModels;
        public ItemConfig PlayerItemConfig;
        
        [Header("Enemies settings")]
        public SpawnParameters EnemiesSpawnParameters;
        public EnemyConfig[] EnemyConfigs;

        public GameConfig CreateGameConfig()
        {
            var playerModel = new PlayerModel
            {
                MoveSpeed = PlayerMoveSpeed,
                RotationSpeed = PlayerRotationSpeed,
                HPModel = new HPModel
                {
                    CurrentHP = PlayerStartHP, BaseMaxHP = PlayerBaseMaxHP,
                    MaxHP = PlayerBaseMaxHP
                },
                AvailableSkillPoints = PlayerAvailableSkillPoints,
                StatModels = StatModels?.CopyModelsDictionary(),
                ItemModel = PlayerItemConfig != null ? PlayerItemConfig.CreateModel() : null,
            };
            
            var gameConfig = new GameConfig
            {
                PlayerModel = playerModel,
                EnemiesSpawnParameters = EnemiesSpawnParameters,
                EnemyModels = EnemyConfigs.Select(config => config.CreateModel()).ToArray(),
            };

            return gameConfig;
        }
    }
}