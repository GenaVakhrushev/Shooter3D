using System;
using Shooter.Core;
using UnityEngine;

namespace Shooter.Player.Stats
{
    [Serializable]
    public class StatModel : IModel
    {
        [SerializeField, Min(1)] private int currentLevel = 1;
        [SerializeField, Min(1)] private int maxLevel = 1;
        [SerializeField, Min(1)] private float amplifyPercentPerLevel = 5;
        
        public event Action ModelChanged;
        
        public int CurrentLevel
        {
            get => currentLevel;
            set
            {
                currentLevel = value;
                ModelChanged?.Invoke();
            }
        }

        public int MaxLevel
        {
            get => maxLevel;
            set
            {
                maxLevel = value;
                ModelChanged?.Invoke();
            }
        }

        public float AmplifyPercentPerLevel
        {
            get => amplifyPercentPerLevel;
            set
            {
                amplifyPercentPerLevel = value;
                ModelChanged?.Invoke();
            }
        }

        public object Clone() => new StatModel
        {
            currentLevel = CurrentLevel,
            maxLevel = MaxLevel,
            amplifyPercentPerLevel = AmplifyPercentPerLevel,
        };
    }
}