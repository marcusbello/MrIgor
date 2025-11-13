using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MrIgor.Mvc.Controllers
{
    [Route("[controller]")]
    public class OnboardingController : Controller
    {
        private readonly ILogger<OnboardingController> _logger;

        public OnboardingController(ILogger<OnboardingController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}