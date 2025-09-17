using Shooter.Signals;
using Zenject;

namespace Shooter.Services
{
    public class ExperienceService
    {
        private readonly PlayerService playerService;

        public ExperienceService(SignalBus bus, PlayerService playerService)
        {
            this.playerService = playerService;

            bus.Subscribe<EnemyDiedSignal>(OnEnemyDied);
        }

        private void OnEnemyDied(EnemyDiedSignal enemyDiedSignal)
        {
            playerService.Controller.AddSkillPoint();
        }
    }
}