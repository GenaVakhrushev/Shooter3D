using Shooter.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter.HP
{
    public class HPView : View
    {
        [SerializeField] private Image hpImage;
        [SerializeField] private TMP_Text hpText;
        [SerializeField] private Color fullHPColor = Color.green;
        [SerializeField] private Color noHPColor = Color.red;

        public void UpdateHPInfo(float hp, float maxHP)
        {
            var hpPercent = hp / maxHP;

            if (hpImage != null)
            {
                hpImage.fillAmount = hpPercent;
                hpImage.color = Color.Lerp(noHPColor, fullHPColor, hpPercent);
            }

            if (hpText != null)
            {
                hpText.text = $"{hp} / {maxHP}";
            }
        }
    }
}