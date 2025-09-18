using Shooter.GameManagement;
using Shooter.HP;
using Shooter.Player;
using Shooter.Utils;
using UnityEngine;
using Zenject;

namespace Shooter.Installers
{
    public class GameConfigInstaller : MonoInstaller
    {
        [SerializeField] private GameConfigSO configSO;

        public override void InstallBindings()
        {
            var playerModel = new PlayerModel
            {
                MoveSpeed = configSO.PlayerMoveSpeed,
                RotationSpeed = configSO.PlayerRotationSpeed,
                HPModel = (HPModel)configSO.PlayerHPModel.Clone(),
                AvailableSkillPoints = configSO.PlayerAvailableSkillPoints,
                StatModels = configSO.StatModels?.CopyModelsDictionary(),
                ItemModel = configSO.PlayerItemConfig != null ? configSO.PlayerItemConfig.CreateModel() : null,
            };
            
            var gameConfig = new GameConfig
            {
                PlayerModel = playerModel,
                EnemiesSpawnParameters = configSO.EnemiesSpawnParameters,
                EnemyConfigs = configSO.EnemyConfigs,
            };
            
            Container.BindInstance(gameConfig);
        }
    }
}