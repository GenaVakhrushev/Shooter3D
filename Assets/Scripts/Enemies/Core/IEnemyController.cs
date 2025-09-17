using System;
using Shooter.Core;

namespace Shooter.Enemies.Core
{
    public interface IEnemyController : IController
    {
        public event Action EnemyDied;
    }
}