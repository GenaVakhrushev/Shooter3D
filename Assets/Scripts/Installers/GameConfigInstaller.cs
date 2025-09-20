using System;
using Shooter.GameManagement;
using UnityEngine;
using Zenject;

namespace Shooter.Installers
{
    public class GameConfigInstaller : MonoInstaller
    {
        [SerializeField] private ConfigSource configSource;
        [SerializeField] private GameConfigSO configSO;
        [SerializeField] private TextAsset configJson;

        public override void InstallBindings()
        {
            var gameConfig = configSource switch
            {
                ConfigSource.ScriptableObject => configSO.CreateGameConfig(),
                ConfigSource.Json => GameConfig.FromJson(configJson.text),
                _ => throw new ArgumentOutOfRangeException()
            };

            Container.BindInstance(gameConfig);
        }

        private enum ConfigSource
        {
            ScriptableObject = 0,
            Json = 1,
        }
    }
}