using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Player.Stats
{
    public class StatsViewModel
    {
        private readonly PlayerModel playerModel;
        private readonly PlayerModel tempModel;

        private int skillPointsUsed;

        public event Action<int> AvailableSkillPointsChanged;
        public event Action StatChanged;
        
        public int AvailableSkillPoints => tempModel.AvailableSkillPoints;

        public StatsViewModel(PlayerModel playerModel)
        {
            this.playerModel = playerModel;
            tempModel = (PlayerModel)this.playerModel.Clone();
            
            playerModel.AvailableSkillPointsChanged += PlayerModelOnAvailableSkillPointsChanged;
            tempModel.AvailableSkillPointsChanged += TempModelOnAvailableSkillPointsChanged;
            
            foreach (var (statName, statModel) in tempModel.StatModels)
            {
                statModel.ModelChanged += StatModelOnModelChanged;
            }
        }

        public Dictionary<StatName, StatModel> GetStatModels() => tempModel.StatModels;

        public void AddStat(StatName statName)
        {
            var statModel = tempModel.StatModels[statName];
            var newLevel = statModel.CurrentLevel + 1;
            
            statModel.CurrentLevel = Mathf.Min(newLevel, statModel.MaxLevel);
            tempModel.AvailableSkillPoints--;
            skillPointsUsed++;
        }

        public void Submit()
        {
            skillPointsUsed = 0;
            
            playerModel.AvailableSkillPoints = tempModel.AvailableSkillPoints;
            
            foreach (var (statName, statModel) in playerModel.StatModels)
            {
                statModel.CurrentLevel = tempModel.StatModels[statName].CurrentLevel;
            }
        }

        public void Reset()
        {
            skillPointsUsed = 0;
            
            tempModel.AvailableSkillPoints = playerModel.AvailableSkillPoints;
            
            foreach (var (statName, statModel) in tempModel.StatModels)
            {
                statModel.CurrentLevel = playerModel.StatModels[statName].CurrentLevel;
            }
        }
        
        private void PlayerModelOnAvailableSkillPointsChanged(int skillPoints)
        {
            tempModel.AvailableSkillPoints = skillPoints - skillPointsUsed;
        }

        private void TempModelOnAvailableSkillPointsChanged(int skillPoints)
        {
            AvailableSkillPointsChanged?.Invoke(tempModel.AvailableSkillPoints);
        }

        private void StatModelOnModelChanged()
        {
            StatChanged?.Invoke();
        }
    }
}