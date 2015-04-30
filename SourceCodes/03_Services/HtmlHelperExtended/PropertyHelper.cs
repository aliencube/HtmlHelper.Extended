using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Aliencube.HtmlHelper.Extended
{
    public static class PropertyHelper
    {
        public static IDictionary<string, object> ConvertAnonymousObjectToDictionary(object attributes)
        {
            var dictionary = new Dictionary<string, object>();
            if (attributes == null)
            {
                return dictionary;
            }

            var pis = attributes.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var pi in pis)
            {
                var key = pi.Name;
                var value = pi.GetValue(attributes);
                dictionary.Add(key, value);
            }
            return dictionary;
        }
    }
}