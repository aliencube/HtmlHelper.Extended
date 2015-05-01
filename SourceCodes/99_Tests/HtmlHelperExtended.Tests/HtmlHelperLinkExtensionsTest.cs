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
        public void GivenLinkTextAndHref_Should_ReturnHtmlTagString(string linkText, string href)
        {
            var link = this._htmlHelper.Link(linkText, href);

            link.ToHtmlString().Should().Contain(">" + linkText + "</a>");
            link.ToHtmlString().Should().Contain("href=\"" + href + "\"");
        }

        [Test]
        [TestCase("Test Link Text", "http://google.com", "TestTitle", "class1 class2")]
        public void GivenLinkTextHrefAndAttributes_Should_ReturnHtmlTagString(string linkText, string href, string title, string @class)
        {
            var attributes = new { title = title, @class = @class };
            var link = this._htmlHelper.Link(linkText, href, attributes);

            link.ToHtmlString().Should().Contain(">" + linkText + "</a>");
            link.ToHtmlString().Should().Contain("href=\"" + href + "\"");
            link.ToHtmlString().Should().Contain("title=\"" + title + "\"");
            link.ToHtmlString().Should().Contain("class=\"" + @class + "\"");
        }
    }
}