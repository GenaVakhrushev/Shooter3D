using System;
using Shooter.Enemies.Core;
using Shooter.HP;

namespace Shooter.Enemies.Features.PassiveEnemy
{
    public class PassiveEnemyModel : EnemyModel
    {
        public float NextPositionRange;
        public float NextPositionDelay;
        
        public override object Clone() => new PassiveEnemyModel
            {
                Name = Name,
                MoveSpeed = MoveSpeed,
                RotationSpeed = RotationSpeed,
                HPModel = (HPModel)HPModel.Clone(),
                NextPositionRange = NextPositionRange,
                NextPositionDelay = NextPositionDelay,
            };

        public override Type GetControllerType() => typeof(PassiveEnemyController);
    }
}