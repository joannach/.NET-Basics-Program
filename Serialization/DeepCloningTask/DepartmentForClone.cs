namespace DeepCloningTask
{
    [Serializable]
    public class DepartmentForClone : ICloneable
    {
        public DepartmentForClone() { }

        public string DepartmentName { get; set; }

        public List<EmployeeForClone> Employees { get; set; }

        public object Clone()
        {
            DepartmentForClone departmentCopy = this.MemberwiseClone() as DepartmentForClone;
            departmentCopy.Employees = new List<EmployeeForClone>();
            departmentCopy.Employees = this.Employees;
            return departmentCopy;
        }
    }
}
