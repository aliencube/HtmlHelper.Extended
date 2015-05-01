using System;
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
        [TestCase("http://google.com", "TestAction")]
        public void GivenSrcAndActionName_Should_ReturnHtmlTagString(string src, string actionName)
        {
            var link = this._htmlHelper.ImageActionLink(src, actionName);

            link.ToHtmlString().Should().Contain("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/home/" + actionName + "\"");
            link.ToHtmlString().Should().Contain("><img");
            link.ToHtmlString().Should().Contain("src=\"" + src + "\"");
        }

        [Test]
        [TestCase("http://google.com", "TestAction", "TestTitle", null)]
        [TestCase("http://google.com", "TestAction", null, "class1 class2")]
        [TestCase("http://google.com", "TestAction", "TestTitle", "class1 class2")]
        public void GivenSrcActionNameAndAttributes_Should_ReturnHtmlTagString(string src, string actionName, string title, string @class)
        {
            var htmlAttributes = String.IsNullOrWhiteSpace(title) ? null : new { title = title };
            var imageAttributes = String.IsNullOrWhiteSpace(@class) ? null : new { @class = @class };

            var link = this._htmlHelper.ImageActionLink(src, actionName, htmlAttributes, imageAttributes);

            link.ToHtmlString().Should().Contain("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/home/" + actionName + "\"");
            link.ToHtmlString().Should().Contain("><img");
            link.ToHtmlString().Should().Contain("src=\"" + src + "\"");

            if (htmlAttributes != null)
            {
                link.ToHtmlString().Should().Contain("title=\"" + htmlAttributes.title + "\"");
            }

            if (imageAttributes != null)
            {
                link.ToHtmlString().Should().Contain("class=\"" + imageAttributes.@class + "\"");
            }
        }

        [Test]
        [TestCase("http://google.com", "TestAction", 1)]
        public void GivenSrcActionNameAndRouteValues_Should_ReturnHtmlTagString(string src, string actionName, int id)
        {
            var routeValues = new { id = id };

            var link = this._htmlHelper.ImageActionLink(src, actionName, routeValues);

            link.ToHtmlString().Should().Contain("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/home/" + actionName + "/" + id + "\"");
            link.ToHtmlString().Should().Contain("><img");
            link.ToHtmlString().Should().Contain("src=\"" + src + "\"");
        }

        [Test]
        [TestCase("http://google.com", "TestAction", 1, "TestTitle", null)]
        [TestCase("http://google.com", "TestAction", 1, null, "class1 class2")]
        [TestCase("http://google.com", "TestAction", 1, "TestTitle", "class1 class2")]
        public void GivenSrcActionNameRouteValuesAndAttributes_Should_ReturnHtmlTagString(string src, string actionName, int id, string title, string @class)
        {
            var routeValues = new { id = id };
            var htmlAttributes = String.IsNullOrWhiteSpace(title) ? null : new { title = title };
            var imageAttributes = String.IsNullOrWhiteSpace(@class) ? null : new { @class = @class };

            var link = this._htmlHelper.ImageActionLink(src, actionName, routeValues, htmlAttributes, imageAttributes);

            link.ToHtmlString().Should().Contain("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/home/" + actionName + "/" + id + "\"");
            link.ToHtmlString().Should().Contain("><img");
            link.ToHtmlString().Should().Contain("src=\"" + src + "\"");

            if (htmlAttributes != null)
            {
                link.ToHtmlString().Should().Contain("title=\"" + htmlAttributes.title + "\"");
            }

            if (imageAttributes != null)
            {
                link.ToHtmlString().Should().Contain("class=\"" + imageAttributes.@class + "\"");
            }
        }

        [Test]
        [TestCase("http://google.com", "TestAction", "TestController")]
        public void GivenSrcActionNameAndController_Should_ReturnHtmlTagString(string src, string actionName, string controllerName)
        {
            var link = this._htmlHelper.ImageActionLink(src, actionName, controllerName);

            link.ToHtmlString().Should().Contain("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/" + controllerName + "/" + actionName + "\"");
            link.ToHtmlString().Should().Contain("><img");
            link.ToHtmlString().Should().Contain("src=\"" + src + "\"");
        }

        [Test]
        [TestCase("http://google.com", "TestAction", "TestController", "TestTitle", null)]
        [TestCase("http://google.com", "TestAction", "TestController", null, "class1 class2")]
        [TestCase("http://google.com", "TestAction", "TestController", "TestTitle", "class1 class2")]
        public void GivenSrcActionNameControllerAndAttributes_Should_ReturnHtmlTagString(string src, string actionName, string controllerName, string title, string @class)
        {
            var htmlAttributes = String.IsNullOrWhiteSpace(title) ? null : new { title = title };
            var imageAttributes = String.IsNullOrWhiteSpace(@class) ? null : new { @class = @class };

            var link = this._htmlHelper.ImageActionLink(src, actionName, controllerName, htmlAttributes, imageAttributes);

            link.ToHtmlString().Should().Contain("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/" + controllerName + "/" + actionName + "\"");
            link.ToHtmlString().Should().Contain("><img");
            link.ToHtmlString().Should().Contain("src=\"" + src + "\"");

            if (htmlAttributes != null)
            {
                link.ToHtmlString().Should().Contain("title=\"" + htmlAttributes.title + "\"");
            }

            if (imageAttributes != null)
            {
                link.ToHtmlString().Should().Contain("class=\"" + imageAttributes.@class + "\"");
            }
        }

        [Test]
        [TestCase("http://google.com", "TestAction", "TestController", 1)]
        public void GivenSrcActionNameControllerNameAndRouteValues_Should_ReturnHtmlTagString(string src, string actionName, string controllerName, int id)
        {
            var routeValues = new { id = id };

            var link = this._htmlHelper.ImageActionLink(src, actionName, controllerName, routeValues);

            link.ToHtmlString().Should().Contain("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/" + controllerName + "/" + actionName + "/" + Convert.ToString(id) + "\"");
            link.ToHtmlString().Should().Contain("><img");
            link.ToHtmlString().Should().Contain("src=\"" + src + "\"");
        }

        [Test]
        [TestCase("http://google.com", "TestAction", "TestController", 1, "TestTitle", null)]
        [TestCase("http://google.com", "TestAction", "TestController", 1, null, "class1 class2")]
        [TestCase("http://google.com", "TestAction", "TestController", 1, "TestTitle", "class1 class2")]
        public void GivenSrcActionNameControllerNameRouteValuesAndAttributes_Should_ReturnHtmlTagString(string src, string actionName, string controllerName, int id, string title, string @class)
        {
            var routeValues = new { id = id };
            var htmlAttributes = String.IsNullOrWhiteSpace(title) ? null : new { title = title };
            var imageAttributes = String.IsNullOrWhiteSpace(@class) ? null : new { @class = @class };

            var link = this._htmlHelper.ImageActionLink(src, actionName, controllerName, routeValues, htmlAttributes, imageAttributes);

            link.ToHtmlString().Should().Contain("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/" + controllerName + "/" + actionName + "/" + Convert.ToString(id) + "\"");
            link.ToHtmlString().Should().Contain("><img");
            link.ToHtmlString().Should().Contain("src=\"" + src + "\"");

            if (htmlAttributes != null)
            {
                link.ToHtmlString().Should().Contain("title=\"" + htmlAttributes.title + "\"");
            }

            if (imageAttributes != null)
            {
                link.ToHtmlString().Should().Contain("class=\"" + imageAttributes.@class + "\"");
            }
        }
    }
}