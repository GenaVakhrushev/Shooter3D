using Shooter.Enemies.Core;
using Shooter.HP;
using UnityEngine;

namespace Shooter.Enemies.Features.PassiveEnemy
{
    [CreateAssetMenu(fileName = nameof(PassiveEnemyConfig), menuName = "Configs/Enemies/" + nameof(PassiveEnemyConfig), order = 0)]
    public class PassiveEnemyConfig : EnemyConfig
    {
        public float NextPositionRange;
        public float NextPositionDelay;

        public override EnemyModel CreateModel() => new PassiveEnemyModel
        {
            Name = Name,
            MoveSpeed = MoveSpeed,
            RotationSpeed = RotationSpeed,
            HPModel = new HPModel{CurrentHP = Random.Range(0, MaxHP), MaxHP = MaxHP},
            NextPositionRange = NextPositionRange,
            NextPositionDelay = NextPositionDelay,
        };
    }
}