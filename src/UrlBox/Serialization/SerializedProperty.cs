using System.Reflection;
using System.Runtime.Serialization;

namespace UrlBox.Serialization
{
    internal sealed class SerializedProperty
    {
        private readonly PropertyInfo property;

        public SerializedProperty(PropertyInfo property, DataMemberAttribute member)
        {
            this.Name = member.Name;
            this.property = property;
        }

        public string Name { get; }

        public object GetValue(object instance)
        {
            return property.GetValue(instance);
        }
    }
}
