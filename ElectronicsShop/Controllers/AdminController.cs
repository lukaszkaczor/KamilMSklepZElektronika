using System.Web.Mvc;

namespace ElectronicsShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }
    }
}