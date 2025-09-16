using Shooter.Services;

namespace Shooter.GameManagement
{
    public class GameManager
    {
        private readonly PlayerService playerService;
        private readonly ShooterInputActions inputActions;

        public GameManager(PlayerService playerService, ShooterInputActions inputActions)
        {
            this.playerService = playerService;
            this.inputActions = inputActions;
        }
        
        public void StartGame()
        {
            playerService.CreatePlayer();
            inputActions.Enable();
        }
    }
}