namespace DeepCloningTask
{
    public class EmployeeForClone : ICloneable<EmployeeForClone>
    {
        public EmployeeForClone() { }
        public string EmployeeName { get; set; }

        public EmployeeForClone Clone()
        {
            return (EmployeeForClone)MemberwiseClone();
        }
    }
}
