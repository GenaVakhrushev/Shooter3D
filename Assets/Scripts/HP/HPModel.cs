using System;
using Shooter.Core;

namespace Shooter.HP
{
    [Serializable]
    public class HPModel : IModel
    {
        public float CurrentHP;
        public float MaxHP;

        public object Clone() => new HPModel { CurrentHP = CurrentHP, MaxHP = MaxHP };
    }
}