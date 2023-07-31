using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SerializationHelper
{
    [Serializable]
    [XmlType("Employee")]
    public class Employee
    {
        [XmlElement("Name", DataType = "string")]
        public string EmpoyeeName { get; set; }
    }
}