using AgileWorks.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgileWorks.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {
            return RedirectToAction("Index", "Tickets");
        }
    }
}
