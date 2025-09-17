using Shooter.HP;
using UnityEngine;

namespace Shooter.Enemies.Core
{
    public abstract class EnemyConfig : ScriptableObject
    {
        public string Name;
        public float MoveSpeed;
        public float RotationSpeed;
        public float MaxHP;
        public EnemyView EnemyView;

        public abstract EnemyModel CreateModel();
    }
}