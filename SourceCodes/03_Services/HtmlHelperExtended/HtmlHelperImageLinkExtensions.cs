using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Aliencube.HtmlHelper.Extended
{
    /// <summary>
    /// This represents the extension methods entity for the <c>HtmlHelper</c> class.
    /// </summary>
    public static class HtmlHelperImageLinkExtensions
    {
        /// <summary>
        /// Renders the &lt;a&gt; tag with image.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="src">Image file location.</param>
        /// <param name="href">Link URL.</param>
        /// <param name="htmlAttributes">List of attributes used for the {a} tag.</param>
        /// <param name="imageAttributes">List of attributes for the {img} tag.</param>
        /// <returns>Returns the &lt;a&gt; tag with image.</returns>
        public static MvcHtmlString ImageLink(this System.Web.Mvc.HtmlHelper htmlHelper, string src, string href, object htmlAttributes = null, object imageAttributes = null)
        {
            if (String.IsNullOrWhiteSpace(src))
            {
                throw new ArgumentNullException("src");
            }

            if (String.IsNullOrWhiteSpace(href))
            {
                throw new ArgumentNullException("href");
            }

            return ImageLink(htmlHelper, src, href, System.Web.Mvc.HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), System.Web.Mvc.HtmlHelper.AnonymousObjectToHtmlAttributes(imageAttributes));
        }

        /// <summary>
        /// Renders the &lt;a&gt; tag with image.
        /// </summary>
        /// <param name="htmlHelper"><c>HtmlHelper</c> instance.</param>
        /// <param name="src">Image file location.</param>
        /// <param name="href">Link URL.</param>
        /// <param name="htmlAttributes">List of attributes used for the {a} tag.</param>
        /// <param name="imageAttributes">List of attributes for the {img} tag.</param>
        /// <returns>Returns the &lt;a&gt; tag with image.</returns>
        public static MvcHtmlString ImageLink(this System.Web.Mvc.HtmlHelper htmlHelper, string src, string href, IDictionary<string, object> htmlAttributes = null, IDictionary<string, object> imageAttributes = null)
        {
            if (String.IsNullOrWhiteSpace(src))
            {
                throw new ArgumentNullException("src");
            }

            if (String.IsNullOrWhiteSpace(href))
            {
                throw new ArgumentNullException("href");
            }

            var link = htmlHelper.Link(".", href, htmlAttributes);
            var image = htmlHelper.Image(src, imageAttributes);
            return new MvcHtmlString(link.ToHtmlString().Replace(">.</a>", ">" + image.ToHtmlString() + "</a>"));
        }
    }
}