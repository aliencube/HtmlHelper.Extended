using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Aliencube.HtmlHelper.Extended.Tests
{
    [TestFixture]
    public class HtmlHelperImageExtensionsTest
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
        [TestCase("http://google.com")]
        [TestCase("http://google.com", "alt=TestTitle", "class=class1 class2")]
        public void GivenSrcAndAttributes_Should_ReturnHtmlTagString(string src, params string[] htmlAttributes)
        {
            Dictionary<string, object> attributes = null;
            if (htmlAttributes != null)
            {
                attributes = htmlAttributes.Select(htmlAttribute => htmlAttribute.Split('='))
                                           .ToDictionary<string[], string, object>(segments => segments[0], segments => segments[1]);
            }
            var image = this._htmlHelper.Image(src, attributes);

            image.ToHtmlString().Should().Contain("src=\"" + src + "\"");

            if (attributes == null)
            {
                return;
            }

            foreach (var attribute in attributes)
            {
                image.ToHtmlString().Should().Contain(attribute.Key + "=\"" + attribute.Value + "\"");
            }
        }
    }
}