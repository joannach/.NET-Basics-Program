using Newtonsoft.Json;
using SerializationHelper;

namespace JsonSerialization
{
    public class JsonSerializator : ToFileSerializator
    {
        public override T Deserialize<T>(string pathToFileToDeserialize) 
            => JsonConvert.DeserializeObject<T>(File.ReadAllText(pathToFileToDeserialize));

        public override void Serialize(object objToSerialize, string pathToFile)
        {
            File.WriteAllText(pathToFile, JsonConvert.SerializeObject(objToSerialize));
        }
    }
}
