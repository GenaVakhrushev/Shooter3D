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
            playerModel.ItemModel = configSO.PlayerItem != null ? (ItemModel)configSO.PlayerItem.ItemModel.Clone() : null;
            
            var gameConfig = new GameConfig
            {
                PlayerModel = playerModel,
            };
            
            Container.BindInstance(gameConfig);
        }
    }
}