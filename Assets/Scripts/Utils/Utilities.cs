using System.IO;
using Newtonsoft.Json;

namespace Shooter.Utils
{
    public static class Utilities
    {
        private static JsonSerializerSettings Settings => new()
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Objects,
        };
        
        public static T FromJson<T>(string json)
        {
            var serializer = JsonSerializer.Create(Settings);

            using var stringReader = new StringReader(json);
            using var jsonTextReader = new JsonTextReader(stringReader);
            
            return serializer.Deserialize<T>(jsonTextReader);
        }

        public static string ToJson(object obj)
        {
            var serializer = JsonSerializer.Create(Settings);

            using var stringWriter = new StringWriter();
            using JsonWriter writer = new JsonTextWriter(stringWriter);
                
            serializer.Serialize(writer, obj);

            return stringWriter.ToString();
        }
    }
}