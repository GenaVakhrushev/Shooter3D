using UnityEngine;
using UnityEngine.UI;

namespace Shooter.UI
{
    public class GameScreen : Screen
    {
        [SerializeField] private Button statsButton;
        [SerializeField] private StatsScreen statsScreen;

        private void Awake()
        {
            statsButton.onClick.AddListener(statsScreen.Show);
        }
    }
}