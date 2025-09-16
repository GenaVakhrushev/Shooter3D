using System;
using Shooter.Core;
using Shooter.HP;

namespace Shooter.Player
{
    [Serializable]
    public class PlayerModel : IModel
    {
        public float MoveSpeed;
        public float RotationSpeed;
        public HPModel HPModel;

        public object Clone() => new PlayerModel { MoveSpeed = MoveSpeed, RotationSpeed = RotationSpeed, HPModel = (HPModel)HPModel.Clone() };
    }
}