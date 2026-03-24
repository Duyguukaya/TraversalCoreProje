using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
