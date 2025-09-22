using System.Threading;
using System.Threading.Tasks;
using Shooter.Enemies.Core;
using Shooter.Enemies.Spawn;
using Shooter.Services;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Shooter.GameManagement
{
    public class GameManager
    {
        private readonly PlayerService playerService;
        private readonly ShooterInputActions inputActions;
        private readonly EnemySpawner enemySpawner;
        private readonly GameConfig gameConfig;
        
        private CancellationTokenSource spawnTokenSource;

        public GameManager(PlayerService playerService, ShooterInputActions inputActions, EnemySpawner enemySpawner, GameConfig gameConfig)
        {
            this.playerService = playerService;
            this.inputActions = inputActions;
            this.enemySpawner = enemySpawner;
            this.gameConfig = gameConfig;
            
            inputActions.UI.ShowCursor.performed += ShowCursorOnPerformed;
        }
        
        public void StartGame()
        {
            playerService.CreatePlayer();
            inputActions.Enable();

            StartSpawn();
            
            HideCursor();
        }

        public void ShowCursor()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public void HideCursor()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private async void StartSpawn()
        {
            for (var i = 0; i < gameConfig.EnemiesSpawnParameters.StartSpawnCount; i++)
            {
                SpawnEnemy();
            }

            spawnTokenSource = new CancellationTokenSource();

            while (true)
            {
                await Task.Delay((int)(gameConfig.EnemiesSpawnParameters.SpawnSecondsInterval * 1000));

                if (!Application.isPlaying || spawnTokenSource.IsCancellationRequested)
                {
                    return;
                }

                SpawnEnemy();
            }
        }
        
        private void SpawnEnemy()
        {
            enemySpawner.SpawnEnemy(GetRandomModel());
        }
        
        private EnemyModel GetRandomModel() => gameConfig.EnemyModels[Random.Range(0, gameConfig.EnemyModels.Length)];
        
        private void ShowCursorOnPerformed(InputAction.CallbackContext context)
        {
            ShowCursor();
        }
    }
}