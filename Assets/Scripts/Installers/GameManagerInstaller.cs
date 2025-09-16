using Shooter.GameManagement;
using UnityEngine;
using Zenject;

namespace Shooter.Installers
{
    public class GameManagerInstaller : MonoInstaller
    {
        [SerializeField] private bool autoRun = true;
        
        public override void InstallBindings()
        {
            Container.Bind<GameManager>().AsSingle().NonLazy();
        }

        public void Awake()
        {
            if (autoRun)
            {
                Container.Resolve<GameManager>().StartGame();
            }
        }
    }
}