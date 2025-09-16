using Shooter.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter.HP
{
    public class HPView : View
    {
        [SerializeField] private Image hpImage;
        [SerializeField] private Color fullHPColor = Color.green;
        [SerializeField] private Color noHPColor = Color.red;

        public void UpdateHPImage(float hpPercent)
        {
            hpImage.fillAmount = hpPercent;
            hpImage.color = Color.Lerp(noHPColor, fullHPColor, hpPercent);
        }
    }
}