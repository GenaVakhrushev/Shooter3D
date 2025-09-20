using System.IO;
using Newtonsoft.Json;
using Shooter.Enemies.Core;
using Shooter.Enemies.Spawn;
using Shooter.Player;

namespace Shooter.GameManagement
{
    public class GameConfig
    {
        public PlayerModel PlayerModel;
        public SpawnParameters EnemiesSpawnParameters;
        public EnemyModel[] EnemyModels;
        
        private static JsonSerializerSettings Settings => new()
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Objects,
        };

        public static GameConfig FromJson(string json)
        {
            var serializer = JsonSerializer.Create(Settings);

            using var stringReader = new StringReader(json);
            using var jsonTextReader = new JsonTextReader(stringReader);
            
            return serializer.Deserialize<GameConfig>(jsonTextReader);
        }

        public string ToJson()
        {
            var serializer = JsonSerializer.Create(Settings);

            using var stringWriter = new StringWriter();
            using JsonWriter writer = new JsonTextWriter(stringWriter);
                
            serializer.Serialize(writer, this);

            return stringWriter.ToString();
        }
    }
}