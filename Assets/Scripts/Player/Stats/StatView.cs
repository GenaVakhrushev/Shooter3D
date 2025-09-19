using System;
using Shooter.Core;
using Shooter.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
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

        private void OnEnable()
        {
            UpdateLabelText();
            LocalizationSettings.SelectedLocaleChanged += LocalizationSettingsOnSelectedLocaleChanged;
        }

        private void OnDisable()
        {
            LocalizationSettings.SelectedLocaleChanged -= LocalizationSettingsOnSelectedLocaleChanged;
        }

        private void LocalizationSettingsOnSelectedLocaleChanged(Locale locale)
        {
            UpdateLabelText();
        }

        public void Bind(StatName statName, StatModel statModel)
        {
            StatName = statName;
            StatModel = statModel;

            StatModel.CurrentLevelChanged += UpdatePointsCount;

            UpdateLabelText();
            UpdatePointsCount();
        }

        public void Unbind()
        {
            StatModel.CurrentLevelChanged -= UpdatePointsCount;
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

        private void UpdateLabelText()
        {
            label.text = StatName.GetLocalizedString();
        }

        private void UpdatePointsCount()
        {
            pointsCountText.text = StatModel.CurrentLevel.ToString();
        }
    }
}