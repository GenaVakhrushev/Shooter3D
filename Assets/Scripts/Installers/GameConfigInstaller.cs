using Shooter.GameManagement;
using Shooter.Items.Core;
using Shooter.Player;
using UnityEngine;
using Zenject;

namespace Shooter.Installers
{
    public class GameConfigInstaller : MonoInstaller
    {
        [SerializeField] private GameConfigSO configSO;

        public override void InstallBindings()
        {
            var playerModel = (PlayerModel)configSO.PlayerModel.Clone();
            playerModel.ItemModel = configSO.PlayerItemConfig != null ? configSO.PlayerItemConfig.CreateModel() : null;
            
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