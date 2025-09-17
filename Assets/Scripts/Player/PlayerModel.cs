using System;
using Shooter.Core;
using Shooter.HP;
using Shooter.Items.Core;
using Shooter.Player.Stats;

namespace Shooter.Player
{
    [Serializable]
    public class PlayerModel : IModel
    {
        public float MoveSpeed;
        public float RotationSpeed;
        public HPModel HPModel;
        public PlayerStatsModel StatsModel;
        public ItemModel ItemModel;

        public object Clone() => new PlayerModel
        {
            MoveSpeed = MoveSpeed, 
            RotationSpeed = RotationSpeed,
            HPModel = (HPModel)HPModel?.Clone(),
            StatsModel = (PlayerStatsModel)StatsModel.Clone(),
            ItemModel = (ItemModel)ItemModel?.Clone(),
        };
    }
}