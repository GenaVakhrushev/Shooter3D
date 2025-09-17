using Shooter.Factories;
using Shooter.Services;
using UnityEngine;

namespace Shooter.Enemies.Spawn
{
    public class PositionsEnemiesSpawner : EnemySpawner
    {
        private readonly Transform[] spawnPositions;

        public PositionsEnemiesSpawner(EnemiesFactory enemiesFactory, EnemiesService enemiesService, Transform[] spawnPositions) : base(enemiesFactory, enemiesService)
        {
            this.spawnPositions = spawnPositions;
        }

        protected override Vector3 GetSpawnPosition() => spawnPositions[Random.Range(0, spawnPositions.Length)].position;

        protected override Quaternion GetSpawnRotation() => Quaternion.identity;
    }
}