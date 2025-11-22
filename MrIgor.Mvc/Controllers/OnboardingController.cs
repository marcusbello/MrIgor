using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using MrIgor.Mvc.Models;
using MrIgor.Core.Models;
using MrIgor.Core.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MrIgor.Mvc.Controllers
{
    // Redirect user to register page if not logged in
    [Authorize]
    [Route("[controller]")]
    public class OnboardingController : Controller
    {
        private readonly ILogger<OnboardingController> _logger;
        private readonly UserManager<AspNetUser> _userManager;
        private readonly SignInManager<AspNetUser> _signInManager;
        private readonly ITenantService _tenantService;

        public OnboardingController(ILogger<OnboardingController> logger, UserManager<AspNetUser> userManager, SignInManager<AspNetUser> signInManager, ITenantService tenantService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _tenantService = tenantService;
        }

        public IActionResult Index()
        {
            // chekc if user is already onboarded
            var user = _userManager.GetUserAsync(User).Result;
            if (user != null && user.TenantId != null)
            {
                // redirect to dashboard
                return RedirectToAction("Dashboard", "Index");
            }
            return View();
        }

        // get model binding for plan selection
        [HttpGet]
        public IActionResult Index(string plan)
        {
            ViewBag.SelectedPlan = plan;
            return View();
        }
        // post method to handle form submission
        [HttpPost]
        public async Task<IActionResult> Submit(OnBoardingIndexViewModel model)
        {
            _logger.LogCritical("ONBOARDING SUBMIT HIT");

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            // Get current user (if any)
            var user = await _userManager.GetUserAsync(User);

            // Create a simple domain slug from the school name
            var domain = string.IsNullOrWhiteSpace(model.SchoolName)
                ? null
                : model.SchoolName.Trim().ToLowerInvariant().Replace(" ", "-");

            // Create tenant (initially not paid)
            var tenant = await _tenantService.CreateTenantAsync(
                model.SchoolName,
                domain ?? string.Empty,
                false,
                model.SelectedPlan ?? "Free",
                user?.Email ?? string.Empty
            );
            // Attach tenant to user
            if (user != null)
            {
                user.TenantId = tenant.TenantId;
                // add claim if needed
                var hasTenantClaim = (await _userManager.GetClaimsAsync(user))
                    .Any(c => c.Type == "tenantId");

                if (!hasTenantClaim)
                {
                    await _userManager.AddClaimAsync(user, new Claim("tenantId", tenant.TenantId.ToString()));
                }
                await _userManager.UpdateAsync(user);
            }

            

            // IMPORTANT: Refresh cookie so TenantId is included
            if (user != null)
                await _signInManager.RefreshSignInAsync(user);

            // Create payment link for Pro/Premium tenants only
            var selectedPlan = (model.SelectedPlan ?? "Free").Trim();
            if (selectedPlan.Equals("Pro", StringComparison.OrdinalIgnoreCase) || selectedPlan.Equals("Premium", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    var billingOption = (model.BillingOption ?? "monthly").Trim().ToLowerInvariant();
                    if (billingOption != "monthly" && billingOption != "yearly")
                    {
                        billingOption = "monthly"; // default to monthly if invalid option
                    }
                    var paymentTenant = await _tenantService.MakePayment(tenant.TenantId, billingOption);
                    if (paymentTenant != null && !string.IsNullOrWhiteSpace(paymentTenant.PaymentUrl))
                    {
                        return Redirect(paymentTenant.PaymentUrl);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to create payment link for tenant {TenantId}", tenant.TenantId);
                    // fall through to success page or display an error
                }
            }

            // If we couldn't create a payment link, continue to a generic success page
            return RedirectToAction("Index", "Dashboard");
        }
    }
}