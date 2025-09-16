using Shooter.Databases;
using Shooter.Factories;
using UnityEngine;
using Zenject;

namespace Shooter.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        [SerializeField] private ItemsDatabase itemsDatabase;
        
        public override void InstallBindings()
        {
            Container.Bind<ItemsFactory>().AsSingle().WithArguments(itemsDatabase);
        }
    }
}