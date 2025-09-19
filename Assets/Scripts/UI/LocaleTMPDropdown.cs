using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace Shooter.UI
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public class LocaleTMPDropdown : MonoBehaviour
    {
        private TMP_Dropdown dropdown;
        
        private void Awake()
        {
            dropdown = GetComponent<TMP_Dropdown>();

            var locales = LocalizationSettings.AvailableLocales.Locales;
            dropdown.AddOptions(locales.Select(locale => locale.LocaleName).ToList());
            dropdown.SetValueWithoutNotify(locales.IndexOf(LocalizationSettings.SelectedLocale));
        }
        
        private void OnEnable()
        {
            dropdown.onValueChanged.AddListener(DropdownValueChanged);
            LocalizationSettings.SelectedLocaleChanged += LocalizationSettingsOnSelectedLocaleChanged;
        }

        private void OnDisable()
        {
            dropdown.onValueChanged.RemoveListener(DropdownValueChanged);
            LocalizationSettings.SelectedLocaleChanged -= LocalizationSettingsOnSelectedLocaleChanged;
        }

        private void DropdownValueChanged(int value)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[value];
        }

        private void LocalizationSettingsOnSelectedLocaleChanged(Locale obj)
        {
            var locales = LocalizationSettings.AvailableLocales.Locales;
            dropdown.SetValueWithoutNotify(locales.IndexOf(LocalizationSettings.SelectedLocale));
        }
    }
}