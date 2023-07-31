using SerializationHelper;
using XMLSerialization;

namespace Serialization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DemoXml();
        }
        public static void DemoXml()
        {
            var binarySerializator = new XMLSerializator();
            var departmentBuilder = new DepartmentBuilder();
            var valutToSerialize = departmentBuilder.CreateDepartment("TestDepartment");

            binarySerializator.Serialize(valutToSerialize, "xmlSerialization.xml");
            var result = binarySerializator.Deserialize<Department>("xmlSerialization.xml");
            Console.WriteLine(result.DepartmentName);
        }
    }
}