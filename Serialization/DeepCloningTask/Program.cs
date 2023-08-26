using DeepCloningTask;
using SerializationHelper;

class Program
{
    static void Main(string[] args)
    {
        var departmentBuilder = new TestDepartmentBuilder();
        DepartmentForClone departentOriginal = new DepartmentForClone()
        {
            DepartmentName = "TestDeepCloneDepartment",
            Employees = new List<EmployeeForClone>
            {
                new EmployeeForClone { EmployeeName = "Empl1" },
                new EmployeeForClone { EmployeeName = "Empl2" }
            },
        };
        DepartmentForClone departmentClone = (DepartmentForClone)departentOriginal.Clone();

        Console.WriteLine("Original Department Name : " + departentOriginal.DepartmentName);
        Console.WriteLine("Original first Employee Name : " + departentOriginal.Employees.FirstOrDefault().EmployeeName);
        Console.WriteLine("Original last Employee Name : " + departentOriginal.Employees.Last().EmployeeName);
        Console.WriteLine("");
        Console.WriteLine("Clone Object Department Name (Clone Method) : " + departmentClone.DepartmentName);
        Console.WriteLine("Clone Object first Employee Name (Clone Method) : " + departmentClone.Employees.FirstOrDefault().EmployeeName);
        Console.WriteLine("Clone Object last Employee Name (Clone Method) : " + departmentClone.Employees.Last().EmployeeName);
        Console.WriteLine("");
        Console.ReadKey();
    }
}