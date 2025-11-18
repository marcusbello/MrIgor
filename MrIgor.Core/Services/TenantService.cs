using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stripe;
using MrIgor.Core.Models;

namespace MrIgor.Core.Services
{
    public interface ITenantService
    {
        Task<Tenant> CreateTenantAsync(string name, string domain, bool isPaid, string plan, string adminEmail);
        Task<Tenant?> GetTenantByDomainAsync(string domain);
        Task<Tenant?> GetTenantByIdAsync(Guid id);
        Task UpdateTenantPlanAsync(Guid tenantId, bool isPaid, string plan);
        Task<Tenant?> MakePayment(Guid tenantId, string plan);
    }

    public class TenantService : ITenantService
    {
        private readonly MrIgorDbContext _context;

        public TenantService(MrIgorDbContext context)
        {
            _context = context;
        }
        public async Task<Tenant> CreateTenantAsync(string name, string domain, bool isPaid, string plan, string adminEmail)
        {
            var tenant = new Tenant
            {
                Name = name,
                Domain = domain,
                IsPaid = isPaid,
                SubcriptionPlan = plan,
                CreatedAt = DateTime.UtcNow
            };

            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();

            // update admin email
            var adminUser = await _context.AspNetUsers.FirstOrDefaultAsync(u => u.Email == adminEmail);
            if (adminUser != null)
            {
                adminUser.TenantId = tenant.TenantId;
                _context.AspNetUsers.Update(adminUser);
                await _context.SaveChangesAsync();
            }

            return tenant;
        }

        public async Task<Tenant?> GetTenantByDomainAsync(string domain)
        {
            return await _context.Tenants.FirstOrDefaultAsync(t => t.Domain == domain);
        }

        public async Task<Tenant?> GetTenantByIdAsync(Guid id)
        {
            return await _context.Tenants.FindAsync(id);
        }

        public async Task UpdateTenantPlanAsync(Guid tenantId, bool isPaid, string plan)
        {
            var tenant = await _context.Tenants.FindAsync(tenantId);
            if (tenant == null) return;

            tenant.IsPaid = isPaid;
            tenant.SubcriptionPlan = plan;

            _context.Tenants.Update(tenant);
            await _context.SaveChangesAsync();
        }

        public async Task<Tenant?> MakePayment(Guid tenantId, string plan)
        {
            // fetch the tenant
            var tenant = await _context.Tenants.FindAsync(tenantId);
            if (tenant == null) return null;

            // Get Stripe API key from environment
            var apiKey = Environment.GetEnvironmentVariable("STRIPE_API_KEY");
            if (string.IsNullOrEmpty(apiKey))
                throw new InvalidOperationException("Stripe API key not configured. Set STRIPE_API_KEY environment variable.");
            var product = Environment.GetEnvironmentVariable("STRIPE_PRODCUT_NAME");
            if (string.IsNullOrEmpty(apiKey))
                throw new InvalidOperationException("Stripe Product Name not configured. Set STRIPE_PRODCUT_NAME environment variable.");


            StripeConfiguration.ApiKey = apiKey;

            // Attempt to locate a price that matches the requested plan and duration.
            var priceService = new PriceService();
            var listOptions = new PriceListOptions { Product = product, Limit = 10 };
            var prices = priceService.List(listOptions).ToList();

            // Prefer a price that has matching metadata or nickname.
            Price? selectedPrice = prices.FirstOrDefault(p =>
                (p.Nickname != null && p.Nickname.Equals(plan, StringComparison.OrdinalIgnoreCase)) ||
                (p.Metadata != null && p.Metadata.ContainsKey("plan") && p.Metadata["plan"] == plan) ||
                (p.LookupKey != null && p.LookupKey.Equals(plan, StringComparison.OrdinalIgnoreCase))
            );

            // If duration implies yearly billing, prefer yearly recurring interval
            // if (duration >= 12)
            // {
            //     selectedPrice = prices.FirstOrDefault(p => p.Recurring != null && p.Recurring.Interval == "year" &&
            //         ((p.Nickname != null && p.Nickname.IndexOf(plan, StringComparison.OrdinalIgnoreCase) >= 0) ||
            //          (p.Metadata != null && p.Metadata.ContainsKey("plan") && p.Metadata["plan"] == plan)));
            // }

            // Fallback: pick the first recurring price
            if (selectedPrice == null)
            {
                selectedPrice = prices.FirstOrDefault(p => p.Recurring != null);
            }

            if (selectedPrice == null)
                throw new InvalidOperationException("No Stripe price found to create a payment link.");

            // Create a payment link for the selected price
            var paymentLinkService = new PaymentLinkService();
            var paymentLinkOptions = new PaymentLinkCreateOptions
            {
                LineItems = new List<PaymentLinkLineItemOptions>
                {
                    new PaymentLinkLineItemOptions { Price = selectedPrice.Id, Quantity = 1 }
                }
            };

            paymentLinkOptions.AddExtraParam("metadata[tenantId]", tenant.TenantId.ToString());

            var paymentLink = paymentLinkService.Create(paymentLinkOptions);

            // Save the payment URL to the tenant and update subscription info
            tenant.PaymentUrl = paymentLink.Url;
            tenant.SubcriptionPlan = plan;
            _context.Tenants.Update(tenant);
            await _context.SaveChangesAsync();

            return tenant;
        }
    }
}