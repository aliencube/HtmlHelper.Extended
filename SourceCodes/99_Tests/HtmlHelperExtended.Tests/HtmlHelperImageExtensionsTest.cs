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
        public void GivenSrc_Should_ReturnHtmlTagString(string src)
        {
            var image = this._htmlHelper.Image(src);

            image.ToHtmlString().Should().Contain("src=\"" + src + "\"");
        }

        [Test]
        [TestCase("http://google.com", "TestTitle", "class1 class2")]
        public void GivenSrcAndAttributes_Should_ReturnHtmlTagString(string src, string alt, string @class)
        {
            var attributes = new { alt = alt, @class = @class };
            var image = this._htmlHelper.Image(src, attributes);

            image.ToHtmlString().Should().Contain("src=\"" + src + "\"");
            image.ToHtmlString().Should().Contain("alt=\"" + alt + "\"");
            image.ToHtmlString().Should().Contain("class=\"" + @class + "\"");
        }
    }
}