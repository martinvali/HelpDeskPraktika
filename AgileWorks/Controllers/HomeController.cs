using Microsoft.AspNetCore.Mvc;

namespace AgileWorks.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {
            return RedirectToAction("Index", "Tickets");
        }
    }
}
