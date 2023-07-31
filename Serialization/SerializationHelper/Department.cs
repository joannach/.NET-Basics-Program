using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SerializationHelper
{
    [Serializable]
    [XmlType("Department")]
    public class Department
    {
        [XmlElement("DepartmentName", DataType = "string")]
        public string DepartmentName { get; set; }

        [XmlArray("Employees")]
        [XmlArrayItem("Employe")]
        public List<Employee> Employees { get;set; }
    }
}
