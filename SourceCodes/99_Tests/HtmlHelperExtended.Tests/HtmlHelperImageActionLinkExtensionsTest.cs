using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Aliencube.HtmlHelper.Extended.Tests
{
    [TestFixture]
    public class HtmlHelperImageActionLinkExtensionsTest
    {
        private System.Web.Mvc.HtmlHelper _htmlHelper;

        [SetUp]
        public void Init()
        {
            this._htmlHelper = MvcHelper.GetHtmlHelper();
        }

        [TearDown]
        public void Cleanup()
        {
            this._htmlHelper = null;
        }

        [Test]
        [TestCase("http://google.com", "TestAction", null, null)]
        [TestCase("http://google.com", "TestAction", "title=TestTitle", null)]
        [TestCase("http://google.com", "TestAction", "title=TestTitle", "class=class1 class2")]
        public void GivenSrcHrefAndAttributes_Should_ReturnHtmlTagString(string src, string actionName, string htmlAttributes, string imageAttributes)
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
            var link = this._htmlHelper.ImageActionLink(src, actionName, hAttributes, iAttributes);

            link.ToHtmlString().Should().Contain("><img");
            link.ToHtmlString().Should().MatchRegex("href=\".+/" + actionName + "\"");
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