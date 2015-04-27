using System.Web.Mvc;

namespace Aliencube.HtmlHelper.Extended
{
    /// <summary>
    /// This represents the extension methods entity for the <c>TagBuilder</c> class.
    /// </summary>
    internal static class TagBuilderExtensions
    {
        /// <summary>
        /// Converts the <c>TagBuilder</c> instance to <c>MvcHtmlString</c> object.
        /// </summary>
        /// <param name="tagBuilder"><c>TagBuilder</c> instance.</param>
        /// <param name="renderMode"><c>TagRenderMode</c> enum value.</param>
        /// <returns>Returns <c>MvcHtmlString</c> object.</returns>
        internal static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder, TagRenderMode renderMode)
        {
            return new MvcHtmlString(tagBuilder.ToString(renderMode));
        }
    }
}