using Shooter.Databases;
using Shooter.Factories;
using UnityEngine;
using Zenject;

namespace Shooter.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        [SerializeField] private ItemsDatabase itemsDatabase;
        [SerializeField] private EnemiesDatabase enemiesDatabase;
        
        public override void InstallBindings()
        {
            Container.Bind<ItemsFactory>().AsSingle().WithArguments(itemsDatabase);
            Container.Bind<EnemiesFactory>().AsSingle().WithArguments(enemiesDatabase);
        }
    }
}