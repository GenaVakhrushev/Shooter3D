using Shooter.Services;
using Shooter.Utils;
using Zenject;

namespace Shooter.Installers
{
    public class ControllerServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(ControllersService<>).GetDerivedTypesOfGenericType()).AsSingle();
        }
    }
}