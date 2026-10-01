using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

public class IgnoreEmptyStringResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(
        MemberInfo member,
        MemberSerialization memberSerialization)
    {
        JsonProperty property = base.CreateProperty(member, memberSerialization);

        property.ShouldSerialize = instance =>
        {
            var value = property.ValueProvider.GetValue(instance);

            if (value == null)
                return false;

            if (value is string)
            {
                string str = (string)value;
                if (string.IsNullOrWhiteSpace(str))
                    return false;
            }

            return true;
        };

        return property;
    }
}