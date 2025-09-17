using Shooter.GameManagement;
using Shooter.Signals;
using Shooter.Utils;
using UnityEngine;
using Zenject;

namespace Shooter.Installers
{
    public class GameManagerInstaller : MonoInstaller
    {
        [SerializeField] private bool autoRun = true;
        
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            foreach (var signalType in typeof(ISignal).GetInheritors())
            {
                Container.DeclareSignal(signalType);
            }
            
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