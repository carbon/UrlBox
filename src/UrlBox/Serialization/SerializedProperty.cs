using System.Reflection;
using System.Runtime.Serialization;

namespace UrlBox.Serialization;

internal sealed class SerializedProperty
{
    private readonly PropertyInfo _property;

    public SerializedProperty(PropertyInfo property, DataMemberAttribute member)
    {
        Name = member.Name!;
        _property = property;
    }

    public string Name { get; }

    public object GetValue(object instance)
    {
        return _property.GetValue(instance)!;
    }
}