using System;
using System.Collections.Generic;
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
        [TestCase("http://flickr.com", "http://google.com", null, null)]
        [TestCase("http://flickr.com", "http://google.com", "title=TestTitle", null)]
        [TestCase("http://flickr.com", "http://google.com", null, "border=0")]
        [TestCase("http://flickr.com", "http://google.com", "title=TestTitle", "border=0")]
        public void GivenSrcHrefAndAttributes_Should_ReturnHtmlTagString(string src, string href, string htmlAttributes, string imageAttributes)
        {
            var hAttributes = new Dictionary<string, object>();
            if (!String.IsNullOrWhiteSpace(htmlAttributes))
            {
                hAttributes.Add(htmlAttributes.Split('=')[0], htmlAttributes.Split('=')[1]);
            }

            var iAttributes = new Dictionary<string, object>();
            if (!String.IsNullOrWhiteSpace(imageAttributes))
            {
                iAttributes.Add(imageAttributes.Split('=')[0], imageAttributes.Split('=')[1]);
            }
            var link = this._htmlHelper.ImageLink(src, href, hAttributes, iAttributes);

            link.ToHtmlString().Should().Contain("><img");
            link.ToHtmlString().Should().MatchRegex("href=\"" + href + "\"");
            link.ToHtmlString().Should().Contain("src=\"" + src + "\"");

            foreach (var attribute in hAttributes)
            {
                link.ToHtmlString().Should().Contain(attribute.Key + "=\"" + attribute.Value + "\"");
            }

            foreach (var attribute in iAttributes)
            {
                link.ToHtmlString().Should().Contain(attribute.Key + "=\"" + attribute.Value + "\"");
            }
        }
    }
}