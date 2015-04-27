using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Aliencube.HtmlHelper.Extended.Tests
{
    [TestFixture]
    public class HtmlHelperLinkExtensionsTest
    {
        private System.Web.Mvc.HtmlHelper _htmlHelper;

        [SetUp]
        public void Init()
        {
            var context = Substitute.For<ViewContext>();
            var container = Substitute.For<IViewDataContainer>();
            this._htmlHelper = new System.Web.Mvc.HtmlHelper(context, container);
        }

        [TearDown]
        public void Cleanup()
        {
            this._htmlHelper = null;
        }

        [Test]
        [TestCase("Test Link Text", "http://google.com")]
        [TestCase("Test Link Text", "http://google.com", "title=TestTitle", "class=class1 class2")]
        public void GivenLinkTextHrefAndAttributes_Should_ReturnHtmlTagString(string linkText, string href, params string[] htmlAttributes)
        {
            Dictionary<string, object> attributes = null;
            if (htmlAttributes != null)
            {
                attributes = htmlAttributes.Select(htmlAttribute => htmlAttribute.Split('='))
                                           .ToDictionary<string[], string, object>(segments => segments[0], segments => segments[1]);
            }
            var link = this._htmlHelper.Link(linkText, href, attributes);

            link.ToHtmlString().Should().Contain(">" + linkText + "</a>");
            link.ToHtmlString().Should().Contain("href=\"" + href + "\"");

            if (attributes == null)
            {
                return;
            }

            foreach (var attribute in attributes)
            {
                link.ToHtmlString().Should().Contain(attribute.Key + "=\"" + attribute.Value + "\"");
            }
        }
    }
}