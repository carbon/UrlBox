using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace UrlBox.Serialization;

internal static class Serializer
{
    public static SerializedProperty[] GetProperties<T>()
    {
        var properties = typeof(T).GetProperties();

        var list = new List<SerializedProperty>(properties.Length);

        foreach (var property in properties)
        {
            var dataMember = property.GetCustomAttribute<DataMemberAttribute>();

            if (dataMember is null) continue;

            list.Add(new SerializedProperty(property, dataMember));
        }

        return [.. list];
    }
}