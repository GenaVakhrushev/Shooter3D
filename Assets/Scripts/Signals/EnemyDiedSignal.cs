using Shooter.Enemies.Core;

namespace Shooter.Signals
{
    public class EnemyDiedSignal : ISignal
    {
        public IEnemyController EnemyController;
    }
}