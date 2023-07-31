using SerializationHelper;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
    public class BinarySerializator : ToFileSerializator
    {
        public override void Serialize(object objToSerialize, string pathToFile)
        {
            using (FileStream fs = new FileStream(pathToFile, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, objToSerialize);
            }
        }
        public override T Deserialize<T>(string pathToFileToDeserialize)
        {
            FileStream fs = new FileStream(pathToFileToDeserialize, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            T deserializedObject = (T)formatter.Deserialize(fs);
            return deserializedObject;
        }
    }
}
