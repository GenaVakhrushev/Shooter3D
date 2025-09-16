using Shooter.Player;
using Shooter.Settings;
using UnityEngine;
using Zenject;

namespace Shooter.Installers
{
    public class GameConfigInstaller : MonoInstaller
    {
        [SerializeField] private GameConfigSO configSO;

        public override void InstallBindings()
        {
            var gameConfig = new GameConfig
            {
                PlayerModel = (PlayerModel)configSO.gameConfig.PlayerModel.Clone(),
            };
            
            Container.BindInstance(gameConfig);
        }
    }
}