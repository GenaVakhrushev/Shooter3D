using Shooter.GameManagement;
using Shooter.Player;
using UnityEngine;
using Zenject;

namespace Shooter.Services
{
    public class PlayerService
    {
        private readonly PlayerController playerController;
        private readonly DiContainer container;
        private readonly GameConfig gameConfig;
        private readonly PlayerView playerPrefab;
        private readonly Transform spawnPoint;

        public PlayerController Controller => playerController;

        public PlayerService(DiContainer container, TickableManager tickableManager, GameConfig gameConfig, PlayerView playerPrefab, Transform spawnPoint)
        {
            this.container = container;
            this.gameConfig = gameConfig;
            this.playerPrefab = playerPrefab;
            this.spawnPoint = spawnPoint;
            
            playerController = this.container.Instantiate<PlayerController>();
            tickableManager.Add(playerController);
        }

        public void CreatePlayer()
        {
            var view = playerController.View != null
                ? playerController.View
                : container.InstantiatePrefab(playerPrefab).GetComponent<PlayerView>();
            var model = (PlayerModel)gameConfig.PlayerModel.Clone();
            
            playerController.SetView(view);
            playerController.SetModel(model);
            
            var viewTransform = view.transform;
            viewTransform.position = spawnPoint.position;
            viewTransform.rotation = spawnPoint.rotation;
        }
    }
}