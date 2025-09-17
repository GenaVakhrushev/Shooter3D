using Shooter.Enemies.Spawn;
using UnityEngine;
using Zenject;

namespace Shooter.Installers
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private Transform[] spawnPositions;
        
        public override void InstallBindings()
        {
            Container.Bind<EnemySpawner>().To<PositionsEnemiesSpawner>().AsSingle().WithArguments(spawnPositions);
        }
    }
}