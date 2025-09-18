using System;
using System.Collections.Generic;
using Shooter.Core;
using Shooter.HP;
using Shooter.Items.Core;
using Shooter.Player.Stats;
using Shooter.Utils;
using UnityEngine;

namespace Shooter.Player
{
    [Serializable]
    public class PlayerModel : IModel
    {
        public float MoveSpeed;
        public float RotationSpeed;
        public HPModel HPModel;

        [Space] 
        
        [SerializeField] 
        private int availableSkillPoints;

        public Dictionary<StatName, StatModel> StatModels;

        [Space]
        
        public ItemModel ItemModel;

        public int AvailableSkillPoints
        {
            get => availableSkillPoints;
            set
            {
                availableSkillPoints = value;
                AvailableSkillPointsChanged?.Invoke(availableSkillPoints);
            }
        }

        public event Action<int> AvailableSkillPointsChanged;

        public object Clone() => new PlayerModel
        {
            MoveSpeed = MoveSpeed,
            RotationSpeed = RotationSpeed,
            HPModel = (HPModel)HPModel?.Clone(),
            availableSkillPoints = AvailableSkillPoints,
            StatModels = StatModels?.CopyModelsDictionary(),
            ItemModel = (ItemModel)ItemModel?.Clone(),
        };
    }
}