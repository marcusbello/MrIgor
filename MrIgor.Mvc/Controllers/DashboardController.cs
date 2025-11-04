using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MrIgor.Mvc.Controllers
{
    public class DashboardController : Controller
    {
        // GET: DashboardController
        [Authorize(Roles = "SuperAdmin, Admin, Teacher, Student")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: DashboardController/SuperAdmin
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult SuperAdmin()
        {
            return View();
        }

        // GET: DashboardController/Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }

        // GET: DashboardController/Teacher
        [Authorize(Roles = "Teacher")]
        public ActionResult Teacher()
        {
            return View();
        }

        // GET: DashboardController/Student
        [Authorize(Roles = "Student")]
        public ActionResult Student()
        {
            return View();
        }
    }
}
