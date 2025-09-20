using Shooter.Services;
using Zenject;

namespace Shooter.Installers
{
    public class SavingServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SavingService>().AsSingle().NonLazy();
        }
    }
}