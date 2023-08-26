using System.Reflection;

namespace DeepCloningTask
{
    public class Cloner
    {
        public static T CloneObject<T>(T source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Source object cannot be null.");
            }

            Type type = source.GetType();
            object clonedObject = Activator.CreateInstance(type);

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.CanRead && property.CanWrite)
                {
                    var propertyValue = property.GetType().GetProperties().ToList();
                    if (propertyValue != null && propertyValue.Any())
                    {
                        foreach (var parameter in propertyValue)
                        {
                            if (propertyValue.GetType().IsValueType || propertyValue is string)
                            {
                                property.SetValue(clonedObject, propertyValue);
                            }
                            else
                            {
                                property.SetValue(clonedObject, CloneObject(propertyValue));
                            }
                        }
                    }
                }
            }

            return (T)clonedObject;
        }

    }
}
