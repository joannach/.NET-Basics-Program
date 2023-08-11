using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SerializationHelper
{
    [Serializable]
    [XmlType("Department")]
    public class Department : ISerializable
    {
        public Department() { }

        [XmlElement("DepartmentName", DataType = "string")]
        public string DepartmentName { get; set; }

        [XmlArray("Employees")]
        [XmlArrayItem("Employe")]
        public List<Employee> Employees { get;set; }

        protected Department(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            DepartmentName = info.GetString("DepartmentName");
            Employees = (List<Employee>)info.GetValue("Employees", typeof(List<Employee>));
        }

        public Department(string departmentName, List<Employee> employees)
        {
            DepartmentName = departmentName;
            Employees = employees;
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue("DepartmentName", DepartmentName);
            info.AddValue("Employees", Employees);
        }
    }
}
