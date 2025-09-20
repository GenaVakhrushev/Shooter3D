using System;
using Shooter.Core;
using UnityEngine;

namespace Shooter.Player.Stats
{
    [Serializable]
    public class StatModel : IModel
    {
        [SerializeField, Min(0)] private int currentLevel;
        [SerializeField, Min(1)] public int MaxLevel = 1;
        [SerializeField, Min(1)] public float AmplifyPercentPerLevel = 5;
        
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

        public object Clone() => new StatModel
        {
            currentLevel = CurrentLevel,
            MaxLevel = MaxLevel,
            AmplifyPercentPerLevel = AmplifyPercentPerLevel,
        };
    }
}