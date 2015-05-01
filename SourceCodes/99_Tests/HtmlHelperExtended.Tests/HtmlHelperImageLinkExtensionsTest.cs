using System;
using System.Web.Mvc;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Aliencube.HtmlHelper.Extended.Tests
{
    [TestFixture]
    public class HtmlHelperImageLinkExtensionsTest
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
        [TestCase("http://flickr.com", "http://google.com")]
        public void GivenSrcAndHref_Should_ReturnHtmlTagString(string src, string href)
        {
            var link = this._htmlHelper.ImageLink(src, href);

            link.ToHtmlString().Should().Contain("><img");
            link.ToHtmlString().Should().MatchRegex("href=\"" + href + "\"");
            link.ToHtmlString().Should().Contain("src=\"" + src + "\"");
        }

        [Test]
        [TestCase("http://flickr.com", "http://google.com", "TestTitle", null)]
        [TestCase("http://flickr.com", "http://google.com", null, 0)]
        [TestCase("http://flickr.com", "http://google.com", "TestTitle", 0)]
        public void GivenSrcHrefAndAttributes_Should_ReturnHtmlTagString(string src, string href, string title, int? border)
        {
            var htmlAttributes = String.IsNullOrWhiteSpace(title) ? null : new { title = title };
            var imageAttributes = border == null ? null : new { border = border.Value };
            var link = this._htmlHelper.ImageLink(src, href, htmlAttributes, imageAttributes);

            link.ToHtmlString().Should().Contain("><img");
            link.ToHtmlString().Should().MatchRegex("href=\"" + href + "\"");
            link.ToHtmlString().Should().Contain("src=\"" + src + "\"");

            if (!String.IsNullOrWhiteSpace(title))
            {
                link.ToHtmlString().Should().Contain("title=\"" + title + "\"");
            }

            if (border != null)
            {
                link.ToHtmlString().Should().Contain("border=\"" + border + "\"");
            }
        }
    }
}