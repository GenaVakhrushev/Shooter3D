using Shooter.Enemies.Core;
using Shooter.Signals;
using Zenject;

namespace Shooter.Services
{
    public class EnemiesService : ControllersService<IEnemyController>
    {
        [Inject] private SignalBus bus;
        
        protected override void ControllerCreated(IEnemyController controller)
        {
            base.ControllerCreated(controller);

            controller.EnemyDied += () =>
            {
                bus.Fire(new EnemyDiedSignal());
                ReturnController(controller);
            };
        }
    }
}