using Shooter.GameManagement;
using Shooter.Player;
using Shooter.Utils;
using UnityEngine;

namespace Shooter.Services
{
    public class SavingService
    {
        private const string SAVE_PREFS_NAME = "player-model-save";
        
        private readonly PlayerService playerService;
        private readonly GameConfig gameConfig;

        public SavingService(PlayerService playerService, GameConfig gameConfig)
        {
            this.playerService = playerService;
            this.gameConfig = gameConfig;

            if (PlayerPrefs.HasKey(SAVE_PREFS_NAME))
            {
                var json = PlayerPrefs.GetString(SAVE_PREFS_NAME);
                var model = Utilities.FromJson<PlayerModel>(json);

                this.gameConfig.PlayerModel = model;
            }
            
            Application.quitting += ApplicationOnQuitting;
        }

        private void ApplicationOnQuitting()
        {
            var model = playerService.Controller.Model;
            var json = Utilities.ToJson(model);
            
            PlayerPrefs.SetString(SAVE_PREFS_NAME, json);
        }

        public static void ClearSave()
        {
            PlayerPrefs.DeleteKey(SAVE_PREFS_NAME);
        }
    }
}