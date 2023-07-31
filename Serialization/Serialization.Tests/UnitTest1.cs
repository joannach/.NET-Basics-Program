using SerializationHelper;

namespace Serialization.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var department = new Department();
            department.DepartmentName = "Test";
            var employees = new List<Employee>
            {
                new Employee() { EmpoyeeName = "Employee1" },
                new Employee() { EmpoyeeName = "Employee2" }
            };

            department.Employees = employees;
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}