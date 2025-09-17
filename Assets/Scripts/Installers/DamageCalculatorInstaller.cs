using Shooter.Damage;
using Zenject;

namespace Shooter.Installers
{
    public class DamageCalculatorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<DamageCalculator>().AsSingle();
        }
    }
}