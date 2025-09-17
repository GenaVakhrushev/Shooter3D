using Shooter.Enemies.Core;
using Shooter.Factories;
using Shooter.Services;
using UnityEngine;

namespace Shooter.Enemies.Spawn
{
    public abstract class EnemySpawner
    {
        private readonly EnemiesFactory enemiesFactory;
        private readonly EnemiesService enemiesService;

        protected EnemySpawner(EnemiesFactory enemiesFactory, EnemiesService enemiesService)
        {
            this.enemiesFactory = enemiesFactory;
            this.enemiesService = enemiesService;
        }

        public IEnemyController SpawnEnemy(EnemyConfig enemyConfig)
        {
            var model = enemyConfig.CreateModel();
            var view = enemiesFactory.GetEnemyView(model);
            var controller = enemiesService.GetController(model.GetControllerType());
            
            controller.SetModel(model);
            controller.SetView(view);

            view.transform.position = GetSpawnPosition();
            view.transform.rotation = GetSpawnRotation();

            return controller;
        }

        protected abstract Vector3 GetSpawnPosition();
        protected abstract Quaternion GetSpawnRotation();
    }
}