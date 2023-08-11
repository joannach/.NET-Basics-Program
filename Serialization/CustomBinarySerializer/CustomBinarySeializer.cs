using SerializationHelper;
using System.Runtime.Serialization;

namespace CustomBinarySerializer
{
    public static class CustomBinarySeializer
    {
        public static void SerializeToFile(Department obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                SerializeObject(obj, writer);
            }
        }

        public static ISerializable DeserializeFromFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                return DeserializeObject(reader);
            }
        }

        private static void SerializeObject(Department obj, BinaryWriter writer)
        {
            SerializationInfo info = new SerializationInfo(typeof(Department), new FormatterConverter());
            StreamingContext context = new StreamingContext(StreamingContextStates.File);

            obj.GetObjectData(info, context);

            foreach (SerializationEntry entry in info)
            {
                writer.Write(entry.Name);
                writer.Write((bool)entry.Value);
            }
        }

        private static ISerializable DeserializeObject(BinaryReader reader)
        {
            // Implement deserialization logic here
            // You need to know the type of the object being deserialized

            string typeName = reader.ReadString();

            switch (typeName)
            {
                case "Department":
                    string departmentName = reader.ReadString();
                    int employeeCount = reader.ReadInt32();

                    List<Employee> employees = new List<Employee>();
                    for (int i = 0; i < employeeCount; i++)
                    {
                        employees.Add((Employee)DeserializeObject(reader));
                    }

                    return new Department(departmentName, employees);

                case "Employee":
                    string employeeName = reader.ReadString();
                    return new Employee(employeeName);

                default:
                    throw new InvalidOperationException("Unknown type during deserialization");
            }
        }
    }
}
