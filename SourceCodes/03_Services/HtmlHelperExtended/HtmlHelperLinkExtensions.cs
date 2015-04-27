using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Aliencube.HtmlHelper.Extended
{
    /// <summary>
    /// This represents the extension methods entity for the <c>HtmlHelper</c> class.
    /// </summary>
    public static class HtmlHelperLinkExtensions
    {
        /// <summary>
        /// Renders the anchor tag.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="linkText">Image file location.</param>
        /// <param name="href">MVC action name.</param>
        /// <param name="htmlAttributes">List of attributes used for the {a} tag.</param>
        /// <returns>Returns the anchor tag.</returns>
        public static MvcHtmlString Link(this System.Web.Mvc.HtmlHelper htmlHelper, string linkText, string href, object htmlAttributes = null)
        {
            if (String.IsNullOrWhiteSpace(linkText))
            {
                throw new ArgumentNullException("linkText");
            }

            if (String.IsNullOrWhiteSpace(href))
            {
                throw new ArgumentNullException("href");
            }

            return Link(htmlHelper, linkText, href, System.Web.Mvc.HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Renders the anchor tag.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="linkText">Image file location.</param>
        /// <param name="href">MVC action name.</param>
        /// <param name="htmlAttributes">List of attributes used for the {a} tag.</param>
        /// <returns>Returns the anchor tag.</returns>
        public static MvcHtmlString Link(this System.Web.Mvc.HtmlHelper htmlHelper, string linkText, string href, IDictionary<string, object> htmlAttributes = null)
        {
            if (String.IsNullOrWhiteSpace(linkText))
            {
                throw new ArgumentNullException("linkText");
            }

            if (String.IsNullOrWhiteSpace(href))
            {
                throw new ArgumentNullException("href");
            }

            var tagBuilder = new TagBuilder("a")
                                 {
                                     InnerHtml = linkText
                                 };
            tagBuilder.MergeAttribute("href", href);
            tagBuilder.MergeAttributes(htmlAttributes);

            return tagBuilder.ToMvcHtmlString(TagRenderMode.Normal);
        }
    }
}