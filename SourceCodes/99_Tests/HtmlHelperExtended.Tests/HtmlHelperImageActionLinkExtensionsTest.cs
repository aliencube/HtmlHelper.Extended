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

        //[Test]
        //[TestCase("http://google.com", "TestAction", null, null, null, null)]
        //[TestCase("http://google.com", "TestAction", null, "id=1", null, null)]
        //[TestCase("http://google.com", "TestAction", null, null, "title=TestTitle", null)]
        //[TestCase("http://google.com", "TestAction", null, null, null, "class=class1 class2")]
        //[TestCase("http://google.com", "TestAction", null, "id=1", "title=TestTitle", null)]
        //[TestCase("http://google.com", "TestAction", null, "id=1", null, "class=class1 class2")]
        //[TestCase("http://google.com", "TestAction", null, null, "title=TestTitle", "class=class1 class2")]
        //[TestCase("http://google.com", "TestAction", null, "id=1", "title=TestTitle", "class=class1 class2")]
        //[TestCase("http://google.com", "TestAction", "TestController", null, null, null)]
        //[TestCase("http://google.com", "TestAction", "TestController", "id=1", null, null)]
        //[TestCase("http://google.com", "TestAction", "TestController", null, "title=TestTitle", null)]
        //[TestCase("http://google.com", "TestAction", "TestController", null, null, "class=class1 class2")]
        //[TestCase("http://google.com", "TestAction", "TestController", "id=1", "title=TestTitle", null)]
        //[TestCase("http://google.com", "TestAction", "TestController", "id=1", null, "class=class1 class2")]
        //[TestCase("http://google.com", "TestAction", "TestController", null, "title=TestTitle", "class=class1 class2")]
        //[TestCase("http://google.com", "TestAction", "TestController", "id=1", "title=TestTitle", "class=class1 class2")]
        //public void GivenSrcHrefAndAttributes_Should_ReturnHtmlTagString(string src, string actionName, string controllerName, string routeValues, string htmlAttributes, string imageAttributes)
        //{
        //    var rValues = new { id = String.Empty };
        //    if (!String.IsNullOrWhiteSpace(routeValues))
        //    {
        //        rValues.GetType().GetProperty("id").SetValue(rValues, routeValues.Split('=')[1]);
        //    }

        //    var hAttributes = new Dictionary<string, object>();
        //    if (!String.IsNullOrWhiteSpace(htmlAttributes))
        //    {
        //        hAttributes.Add(htmlAttributes.Split('=')[0], htmlAttributes.Split('=')[1]);
        //    }

        //    var iAttributes = new Dictionary<string, object>();
        //    if (!String.IsNullOrWhiteSpace(imageAttributes))
        //    {
        //        iAttributes.Add(imageAttributes.Split('=')[0], imageAttributes.Split('=')[1]);
        //    }
        //    var link = String.IsNullOrWhiteSpace(controllerName)
        //                   ? this._htmlHelper.ImageActionLink(src, actionName, rValues, hAttributes, iAttributes)
        //                   : this._htmlHelper.ImageActionLink(src, actionName, controllerName, rValues, hAttributes, iAttributes);

        //    link.ToHtmlString().Should().Contain("><img");
        //    if (!String.IsNullOrWhiteSpace(controllerName))
        //    {
        //        if (!String.IsNullOrWhiteSpace(routeValues))
        //        {
        //            link.ToHtmlString().Should().MatchRegex("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/" + controllerName + "/" + actionName + "/" + rValues.id + "\"");
        //        }
        //        else
        //        {
        //            link.ToHtmlString().Should().MatchRegex("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/" + controllerName + "/" + actionName + "\"");
        //        }
        //    }
        //    else
        //    {
        //        if (!String.IsNullOrWhiteSpace(routeValues))
        //        {
        //            link.ToHtmlString().Should().MatchRegex("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/home/" + actionName + "/" + rValues.id + "\"");
        //        }
        //        else
        //        {
        //            link.ToHtmlString().Should().MatchRegex("href=\"" + MvcHelper.APP_PATH_MODIFIER + "/home" + actionName + "\"");
        //        }
        //    }
        //    link.ToHtmlString().Should().Contain("src=\"" + src + "\"");

        //    foreach (var attribute in hAttributes)
        //    {
        //        link.ToHtmlString().Should().Contain(attribute.Key + "=\"" + attribute.Value + "\"");
        //    }

        //    foreach (var attribute in iAttributes)
        //    {
        //        link.ToHtmlString().Should().Contain(attribute.Key + "=\"" + attribute.Value + "\"");
        //    }
        //}
    }
}