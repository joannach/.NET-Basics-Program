namespace SerializationHelper
{
    public class DepartmentBuilder
    {
        public Department Department = new Department();

        public DepartmentBuilder() {}

        public Department CreateDepartment(string departmentName)
        {
            var employeesTest = new List<Employee>()
            {
                new Employee() { EmployeeName = "EmployeeName1"},
                new Employee() { EmployeeName = "EmployeeName2"}
            };

            Department.DepartmentName = departmentName;
            Department.Employees = employeesTest;

            return Department;
        }

        public Department CreateDepartment(string name, List<Employee> employees)
        {
            Department.DepartmentName = name;
            Department.Employees = employees;

            return Department;
        }
    }
}
