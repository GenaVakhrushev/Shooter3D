using Shooter.Player;
using Shooter.Services;
using UnityEngine;
using Zenject;

namespace Shooter.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerView playerPrefab;
        [SerializeField] private Transform spawnPoint;

        public override void InstallBindings()
        {
            Container.Bind<PlayerService>().AsSingle().WithArguments(playerPrefab, spawnPoint);
        }
    }
}