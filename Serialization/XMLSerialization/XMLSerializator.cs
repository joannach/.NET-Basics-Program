using SerializationHelper;
using System.Xml.Serialization;

namespace XMLSerialization
{
    public class XMLSerializator : ToFileSerializator
    {
        public override T Deserialize<T>(string pathToFileToDeserialize)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(pathToFileToDeserialize, FileMode.Open);
            T result = (T)serializer.Deserialize(fs);
            fs.Close();

            return result;
        }

        public override void Serialize(object objToSerialize, string pathToFile)
        {
            XmlSerializer serializer = new XmlSerializer(objToSerialize.GetType());
            FileStream fs = new FileStream(pathToFile, FileMode.Create);
            serializer.Serialize(fs, objToSerialize);
            fs.Close();
        }
    }
}
