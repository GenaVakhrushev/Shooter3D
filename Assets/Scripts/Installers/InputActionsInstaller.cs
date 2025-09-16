using Zenject;

namespace Shooter.Installers
{
    public class InputActionsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ShooterInputActions>().AsSingle();
        }
    }
}