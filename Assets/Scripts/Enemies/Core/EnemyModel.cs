using System;
using Shooter.Core;
using Shooter.HP;

namespace Shooter.Enemies.Core
{
    public abstract class EnemyModel : IModel
    {
        public string Name;
        public float MoveSpeed;
        public float RotationSpeed;
        public HPModel HPModel;

        public abstract object Clone();
        public abstract Type GetControllerType();
    }
}