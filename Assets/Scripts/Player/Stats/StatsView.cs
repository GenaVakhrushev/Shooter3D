using System.Collections.Generic;
using Shooter.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

namespace Shooter.Player.Stats
{
    public class StatsView : View
    {
        [SerializeField] private TMP_Text availableSkillPointsText;
        [SerializeField] private StatView statViewPrefab;
        [SerializeField] private Transform statViewsParent;

        private readonly HashSet<StatView> activeViews = new();
        private ObjectPool<StatView> statViews;

        private StatsViewModel statsViewModel;

        private void Awake()
        {
            statViews = new ObjectPool<StatView>(CreateStatView, ActionOnGetStatView, ActionOnReleaseStatView);
        }

        public void Bind(StatsViewModel target)
        {
            if (statsViewModel != null)
            {
                statsViewModel.AvailableSkillPointsChanged -= StatsViewModelOnAvailableSkillPointsChanged;
                statsViewModel.StatChanged -= StatsViewModelOnStatChanged;
            }
            
            statsViewModel = target;
            
            foreach (var activeView in activeViews)
            {
                statViews.Release(activeView);
            }
            
            if (statsViewModel == null)
            {
                return;
            }
            
            statsViewModel.AvailableSkillPointsChanged += StatsViewModelOnAvailableSkillPointsChanged;
            statsViewModel.StatChanged += StatsViewModelOnStatChanged;
            
            foreach (var (statName, statModel) in statsViewModel.GetStatModels())
            {
                var statView = statViews.Get();

                statView.Bind(statName, statModel);
            }
            
            UpdateView();
        }

        private void StatsViewModelOnAvailableSkillPointsChanged(int skillPoints)
        {
            UpdateView();
        }

        private void StatsViewModelOnStatChanged()
        {
            UpdateView();
        }

        private StatView CreateStatView()
        {
            var statView = Instantiate(statViewPrefab, statViewsParent);
            
            statView.PointAdded += StatViewOnPointAdded;
            
            return statView;
        }

        private void StatViewOnPointAdded(StatName statName)
        {
            statsViewModel.AddStat(statName);
        }

        private void ActionOnGetStatView(StatView statView)
        {
            statView.gameObject.SetActive(true);
            activeViews.Add(statView);
        }

        private void ActionOnReleaseStatView(StatView statView)
        {
            statView.gameObject.SetActive(false);
            statView.Unbind();
            activeViews.Remove(statView);
        }

        private void UpdateView()
        {
            availableSkillPointsText.text = statsViewModel.AvailableSkillPoints.ToString();
            
            var noPoints = statsViewModel.AvailableSkillPoints <= 0;

            foreach (var activeView in activeViews)
            {
                if (noPoints || activeView.StatModel.CurrentLevel == activeView.StatModel.MaxLevel)
                {
                    activeView.DisableAdding();
                }
                else
                {
                    activeView.EnableAdding();
                }
            }
        }
    }
}