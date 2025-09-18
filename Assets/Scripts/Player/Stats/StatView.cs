using System;
using Shooter.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter.Player.Stats
{
    public class StatView : View
    {
        [SerializeField] private TMP_Text label;
        [SerializeField] private TMP_Text pointsCountText;
        [SerializeField] private Button addButton;

        public StatName StatName { get; private set; }
        public StatModel StatModel { get; private set; }
        
        public event Action<StatName> PointAdded;

        private void Awake()
        {
            addButton.onClick.AddListener(() => PointAdded?.Invoke(StatName));
        }

        public void Bind(StatName statName, StatModel statModel)
        {
            StatName = statName;
            StatModel = statModel;

            StatModel.ModelChanged += UpdatePointsCount;

            label.text = StatName.ToString();
            UpdatePointsCount();
        }

        public void Unbind()
        {
            StatModel.ModelChanged -= UpdatePointsCount;
            StatModel = null;
        }

        public void EnableAdding()
        {
            addButton.interactable = true;
        }
        
        public void DisableAdding()
        {
            addButton.interactable = false;
        }

        private void UpdatePointsCount()
        {
            pointsCountText.text = StatModel.CurrentLevel.ToString();
        }
    }
}