using CustomBinarySerializer;
using SerializationHelper;

namespace Serialization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Demo();
        }

        public static void Demo()
        {
            Employee employee = new Employee();
            employee.EmployeeName = "TestCustomBinary";

            var employees = new List<Employee>();
            employees.Add(employee);

            Department department = new Department();
            department.DepartmentName = "TestDepName";
            department.Employees = employees;

            // Serialize the department object to a file
            string filePath = "department.bin";
            CustomBinarySeializer.SerializeToFile(department, filePath);
            Console.WriteLine("Serialized to file: " + filePath);

            // Deserialize the department object from the file
            Department deserializedDepartment = (Department)CustomBinarySeializer.DeserializeFromFile(filePath);
            Console.WriteLine("Deserialized Department:");
            Console.WriteLine($"Department Name: {deserializedDepartment.DepartmentName}");
            Console.WriteLine("Employees:");
            foreach (Employee emp in deserializedDepartment.Employees)
            {
                Console.WriteLine($"  Employee Name: {emp.EmployeeName}");
            }
        }
    }
}