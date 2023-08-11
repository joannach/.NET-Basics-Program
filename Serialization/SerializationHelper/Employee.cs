using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SerializationHelper
{
    [Serializable]
    [XmlType("Employee")]
    public class Employee : ISerializable
    {
        public Employee(){}

        [XmlElement("Name", DataType = "string")]
        public string EmployeeName { get; set; }

        protected Employee(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            EmployeeName = info.GetString("EmployeeName");
        }

        public Employee(string employeeName)
        {
            EmployeeName = employeeName;
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue("EmployeeName", EmployeeName);
        }
    }
}