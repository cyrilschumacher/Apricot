using System.Reflection;

namespace Apricot.Shared.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="object"/>.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        ///     Gets property value of the <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance">The object instance.</param>
        /// <param name="propertyValue">The property value.</param>
        /// <returns>The property value.</returns>
        public static object GetPropertyValue(this object instance, string propertyValue)
        {
            return instance.GetType().GetTypeInfo().GetDeclaredProperty(propertyValue).GetValue(instance);
        }
    }
}
