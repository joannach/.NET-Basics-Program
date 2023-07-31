namespace SerializationHelper
{
    public abstract class ToFileSerializator
    {
        public abstract void Serialize(object objToSerialize, string pathToFile);
        public abstract T Deserialize<T>(string pathToFileToDeserialize);
    }
}
