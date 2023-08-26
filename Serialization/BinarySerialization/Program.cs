using BinarySerialization;

namespace Serialization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DemoBinary();
        }

        public static void DemoBinary()
        {
            var binarySerializator = new BinarySerializator();
            var valutToSerialize = "abc123";
            binarySerializator.Serialize(valutToSerialize, "binarySerialization.dat");
            var result = binarySerializator.Deserialize<string>("binarySerialization.dat");
            Console.WriteLine(result);
        }
    }
}