using System;
using Shooter.Core;
using UnityEngine;

namespace Shooter.Player.Stats
{
    [Serializable]
    public class StatModel : IModel
    {
        [SerializeField, Min(0)] private int currentLevel;
        [SerializeField, Min(1)] private int maxLevel = 1;
        [SerializeField, Min(1)] private float amplifyPercentPerLevel = 5;
        
        public event Action CurrentLevelChanged;
        
        public int CurrentLevel
        {
            get => currentLevel;
            set
            {
                currentLevel = value;
                CurrentLevelChanged?.Invoke();
            }
        }

        public int MaxLevel => maxLevel;
        public float AmplifyPercentPerLevel => amplifyPercentPerLevel;

        public object Clone() => new StatModel
        {
            currentLevel = CurrentLevel,
            maxLevel = MaxLevel,
            amplifyPercentPerLevel = AmplifyPercentPerLevel,
        };
    }
}