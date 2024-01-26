using System.Reflection;
using System.Runtime.Serialization;

namespace UrlBox.Serialization;

internal sealed class SerializedProperty(PropertyInfo property, DataMemberAttribute member)
{
    private readonly PropertyInfo _property = property;

    public string Name { get; } = member.Name!;

    public object GetValue(object instance)
    {
        return _property.GetValue(instance)!;
    }
}