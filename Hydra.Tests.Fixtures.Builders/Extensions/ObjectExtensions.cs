
using System.Reflection;

namespace Hydra.Tests.Fixtures.Builders.Extensions
{
    internal static class ObjectExtensions
    {
        public static bool HasProperty(this object value, string propertyName)
        {
            var property = value as PropertyInfo;
            return property != null &&
                   (property.Name.ToLower().Contains(propertyName.ToLower()));
        }

        public static bool HasPropertyType<T>(this object value)
        {
            var property = value as PropertyInfo;
            return property != null &&
                   (property.PropertyType == typeof(T));
        }

        public static bool HasParameterType<T>(this object value)
        {
            return value is ParameterInfo parameter &&
                   (parameter.ParameterType == typeof(T));
        }
    }
}
