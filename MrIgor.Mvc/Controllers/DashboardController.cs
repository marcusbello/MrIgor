using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MrIgor.Mvc.Controllers
{
    public class DashboardController : Controller
    {
        // GET: DashboardController
        [Authorize(Roles = "Admin, Teacher, Student")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
