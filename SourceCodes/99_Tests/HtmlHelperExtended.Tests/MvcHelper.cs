using System;
using System.Collections;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NSubstitute;

namespace Aliencube.HtmlHelper.Extended.Tests
{
    /// <summary>
    /// This represents the helper entity for <c>HtmlHelper</c>.
    /// </summary>
    public static class MvcHelper
    {
        private const string APP_PATH_MODIFIER = "/$(SESSION)";

        /// <summary>
        /// Gets the fake <c>HtmlHelper</c> instance.
        /// </summary>
        /// <param name="appPath">Application path.</param>
        /// <param name="requestPath">Request path.</param>
        /// <param name="httpMethod">HTTP method.</param>
        /// <param name="protocol">Protocol.</param>
        /// <param name="port">Port number.</param>
        /// <returns>Returns the fake <c>HtmlHelper</c> instance.</returns>
        public static HtmlHelper<object> GetHtmlHelper(string appPath = null, string requestPath = null, string httpMethod = null, string protocol = null, int? port = null)
        {
            if (String.IsNullOrWhiteSpace(appPath))
            {
                appPath = "/";
            }

            if (String.IsNullOrWhiteSpace(protocol))
            {
                protocol = Uri.UriSchemeHttp;
            }

            if (port.GetValueOrDefault() <= 0)
            {
                port = 80;
            }

            var httpContext = GetHttpContext(appPath, requestPath, httpMethod, protocol, port);

            var routeCollection = new RouteCollection();
            var route = new Route("{controller}/{action}/{id}", null)
                        {
                            Defaults = new RouteValueDictionary(new { id = UrlParameter.Optional }),
                        };
            routeCollection.Add(route);

            var routeData = new RouteData();
            routeData.Values.Add("controller", "home");
            routeData.Values.Add("action", "index");

            var viewDataDictionary = new ViewDataDictionary();
            var viewContext = new ViewContext()
                              {
                                  HttpContext = httpContext,
                                  RouteData = routeData,
                                  ViewData = viewDataDictionary,
                              };

            var viewDataContainer = Substitute.For<IViewDataContainer>();
            viewDataContainer.ViewData.Returns(viewDataDictionary);

            var htmlHelper = new HtmlHelper<object>(viewContext, viewDataContainer, routeCollection);
            return htmlHelper;
        }

        /// <summary>
        /// Gets the fake <c>HttpContextBase</c> instance.
        /// </summary>
        /// <param name="appPath">Application path.</param>
        /// <param name="requestPath">Request path.</param>
        /// <param name="httpMethod">HTTP method.</param>
        /// <param name="protocol">Protocol.</param>
        /// <param name="port">Port number.</param>
        /// <returns>Returns the fake <c>HttpContextBase</c> instance.</returns>
        public static HttpContextBase GetHttpContext(string appPath = null, string requestPath = null, string httpMethod = null, string protocol = null, int? port = null)
        {
            var request = Substitute.For<HttpRequestBase>();
            if (!String.IsNullOrWhiteSpace(appPath))
            {
                request.ApplicationPath.Returns(appPath);
                request.RawUrl.Returns(appPath);
            }

            if (!String.IsNullOrWhiteSpace(requestPath))
            {
                request.AppRelativeCurrentExecutionFilePath.Returns(requestPath);
            }

            var url = String.Format("{0}://localhost{1}",
                                    protocol,
                                    (port.GetValueOrDefault() > 0 ? String.Format(":{0}", port) : null));
            var uri = new Uri(url);
            request.Url.Returns(uri);
            request.PathInfo.Returns(String.Empty);

            if (!String.IsNullOrWhiteSpace(httpMethod))
            {
                request.HttpMethod.Returns(httpMethod);
            }

            var context = Substitute.For<HttpContextBase>();
            context.Request.Returns(request);

            context.Session.Returns((HttpSessionStateBase)null);

            var response = Substitute.For<HttpResponseBase>();
            response.ApplyAppPathModifier(Arg.Any<string>())
                    .Returns(p => String.Format("{0}{1}", APP_PATH_MODIFIER, p.Arg<string>()));

            context.Response.Returns(response);

            var items = new Hashtable();
            context.Items.Returns(items);

            return context;
        }
    }
}