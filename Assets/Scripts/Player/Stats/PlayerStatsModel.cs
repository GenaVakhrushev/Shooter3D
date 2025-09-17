using System;
using Shooter.Core;

namespace Shooter.Player.Stats
{
    [Serializable]
    public class PlayerStatsModel : IModel
    {
        public int AvailablePoints;
        public int Speed = 1;
        public int Health = 1;
        public int Damage = 1;

        public object Clone() => new PlayerStatsModel
        {
            AvailablePoints = AvailablePoints,
            Speed = Speed,
            Health = Health,
            Damage = Damage,
        };
    }
}