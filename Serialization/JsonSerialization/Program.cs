using JsonSerialization;
using SerializationHelper;

namespace Serialization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DemoJson();
        }
        public static void DemoJson()
        {
            var jsonSerializator = new JsonSerializator();
            var departmentBuilder = new TestDepartmentBuilder();
            var valutToSerialize = departmentBuilder.CreateDepartment("TestJsonDepartment");

            jsonSerializator.Serialize(valutToSerialize, "jsonSerialization.json");
            var result = jsonSerializator.Deserialize<Department>("jsonSerialization.json");
            Console.WriteLine(result.DepartmentName);
        }
    }
}