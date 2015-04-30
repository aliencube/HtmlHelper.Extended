using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Aliencube.HtmlHelper.Extended.Tests
{
    using System.Linq;

    using NUnit.Framework.Constraints;

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
        [TestCase("http://google.com", "TestAction", null, null, null, null)]
        [TestCase("http://google.com", "TestAction", null, "id=1", null, null)]
        [TestCase("http://google.com", "TestAction", null, null, "title=TestTitle", null)]
        [TestCase("http://google.com", "TestAction", null, null, null, "border=0")]
        [TestCase("http://google.com", "TestAction", null, "id=1", "title=TestTitle", null)]
        [TestCase("http://google.com", "TestAction", null, "id=1", null, "border=0")]
        [TestCase("http://google.com", "TestAction", null, null, "title=TestTitle", "border=0")]
        [TestCase("http://google.com", "TestAction", null, "id=1", "title=TestTitle", "border=0")]
        [TestCase("http://google.com", "TestAction", "TestController", null, null, null)]
        [TestCase("http://google.com", "TestAction", "TestController", "id=1", null, null)]
        [TestCase("http://google.com", "TestAction", "TestController", null, "title=TestTitle", null)]
        [TestCase("http://google.com", "TestAction", "TestController", null, null, "border=0")]
        [TestCase("http://google.com", "TestAction", "TestController", "id=1", "title=TestTitle", null)]
        [TestCase("http://google.com", "TestAction", "TestController", "id=1", null, "border=0")]
        [TestCase("http://google.com", "TestAction", "TestController", null, "title=TestTitle", "border=0")]
        [TestCase("http://google.com", "TestAction", "TestController", "id=1", "title=TestTitle", "border=0")]
        public void GivenSrcHrefAndAttributes_Should_ReturnHtmlTagString(string src, string actionName, string controllerName, string routeValues, string htmlAttributes, string imageAttributes)
        {
            var rValues = new { id = !String.IsNullOrWhiteSpace(routeValues) ? routeValues.Split('=')[1] : null };
            var hAttributes = new { title = !String.IsNullOrWhiteSpace(htmlAttributes) ? htmlAttributes.Split('=')[1] : null };
            var iAttributes = new { border = !String.IsNullOrWhiteSpace(imageAttributes) ? imageAttributes.Split('=')[1] : null };

            var link = String.IsNullOrWhiteSpace(controllerName)
                           ? this._htmlHelper.ImageActionLink(src, actionName, rValues, hAttributes, iAttributes)
                           : this._htmlHelper.ImageActionLink(src, actionName, controllerName, rValues, hAttributes, iAttributes);

            link.ToHtmlString().Should().Contain("><img");
            if (!String.IsNullOrWhiteSpace(controllerName))
            {
                if (!String.IsNullOrWhiteSpace(routeValues))
                {
                    link.ToHtmlString().Should().Contain("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/" + controllerName + "/" + actionName + "/" + rValues.id + "\"");
                }
                else
                {
                    link.ToHtmlString().Should().Contain("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/" + controllerName + "/" + actionName + "\"");
                }
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(routeValues))
                {
                    link.ToHtmlString().Should().Contain("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/home/" + actionName + "/" + rValues.id + "\"");
                }
                else
                {
                    link.ToHtmlString().Should().Contain("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/home/" + actionName + "\"");
                }
            }
            link.ToHtmlString().Should().Contain("src=\"" + src + "\"");
            link.ToHtmlString().Should().Contain("title=\"" + hAttributes.title + "\"");
            link.ToHtmlString().Should().Contain("border=\"" + iAttributes.border + "\"");
        }
    }
}