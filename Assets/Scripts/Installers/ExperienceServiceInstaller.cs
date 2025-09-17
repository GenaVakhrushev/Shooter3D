using Shooter.Services;
using Zenject;

namespace Shooter.Installers
{
    public class ExperienceServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ExperienceService>().AsSingle().NonLazy();
        }
    }
}