using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Routing;

namespace Aliencube.HtmlHelper.Extended
{
    /// <summary>
    /// This represents the helper entity for properties.
    /// </summary>
    public static class PropertyHelper
    {
        /// <summary>
        /// Converts the anonymous type object to the <c>RouteValueDictionary</c> type object.
        /// </summary>
        /// <param name="attributes">Anonymous type object.</param>
        /// <returns>Returns the <c>RouteValueDictionary</c> type object.</returns>
        public static RouteValueDictionary ConvertAnonymousObjectToRouteValueDictionary(object attributes)
        {
            var routeValueDictionary = new RouteValueDictionary();
            if (attributes == null)
            {
                return routeValueDictionary;
            }

            var dictionary = ConvertAnonymousObjectToDictionary(attributes);
            if (dictionary == null || !dictionary.Any())
            {
                return routeValueDictionary;
            }

            routeValueDictionary = ConvertDictionaryToRouteValueDictionary(dictionary);
            return routeValueDictionary;
        }

        /// <summary>
        /// Converts the anonymous type object to the <c>Dictionary{string, object}</c> type object.
        /// </summary>
        /// <param name="attributes">Anonymous type object.</param>
        /// <returns>Returns the <c>Dictionary{string, object}</c> type object.</returns>
        public static IDictionary<string, object> ConvertAnonymousObjectToDictionary(object attributes)
        {
            var dictionary = new Dictionary<string, object>();
            if (attributes == null)
            {
                return dictionary;
            }

            dictionary = attributes.GetType()
                                   .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                   .ToDictionary(pi => pi.Name, pi => pi.GetValue(attributes));
            return dictionary;
        }

        /// <summary>
        /// Converts the <c>Dictionary{string, object}</c> type object to the <c>RouteValueDictionary</c> object.
        /// </summary>
        /// <param name="attributes"><c>Dictionary{string, object}</c> type object.</param>
        /// <returns>Returns the <c>RouteValueDictionary</c> type object.</returns>
        public static RouteValueDictionary ConvertDictionaryToRouteValueDictionary(IDictionary<string, object> attributes)
        {
            var dictionary = new RouteValueDictionary();
            if (attributes == null)
            {
                return dictionary;
            }

            dictionary = new RouteValueDictionary(attributes);
            return dictionary;
        }
    }
}