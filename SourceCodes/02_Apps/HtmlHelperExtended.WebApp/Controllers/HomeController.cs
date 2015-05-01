using System.Web.Mvc;

namespace Aliencube.HtmlHelper.Extended.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Another()
        {
            return View();
        }
    }
}