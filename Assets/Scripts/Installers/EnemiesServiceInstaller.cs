using Shooter.Services;
using Zenject;

namespace Shooter.Installers
{
    public class EnemiesServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemiesService>().AsSingle();
        }
    }
}