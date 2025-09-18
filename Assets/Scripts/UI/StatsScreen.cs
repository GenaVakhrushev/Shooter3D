using Shooter.Player.Stats;
using Shooter.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Shooter.UI
{
    public class StatsScreen : Screen
    {
        [SerializeField] private StatsView statsView;
        [SerializeField] private Button closeButton;
        [SerializeField] private Button applyButton;

        [Inject] private PlayerService playerService;

        private void Awake()
        {
            var statsViewModel = new StatsViewModel(playerService.Controller.Model);
            
            statsView.Bind(statsViewModel);
            
            closeButton.onClick.AddListener(Hide);
            closeButton.onClick.AddListener(statsViewModel.Reset);
            
            applyButton.onClick.AddListener(Hide);
            applyButton.onClick.AddListener(statsViewModel.Submit);
        }
    }
}