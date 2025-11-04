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
            if (User.IsInRole("SuperAdmin"))
            {
                return RedirectToAction("SuperAdmin");
            }
            else if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Admin");
            }
            else if (User.IsInRole("Teacher"))
            {
                return RedirectToAction("Teacher");
            }
            else if (User.IsInRole("Student"))
            {
                return RedirectToAction("Student");
            }
            // Redirect to login page by default
            return RedirectToAction("Login", "Account");
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
