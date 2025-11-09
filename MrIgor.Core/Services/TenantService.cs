using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MrIgor.Core.Models;

namespace MrIgor.Core.Services
{
    public interface ITenantService
    {
        Task<Tenant> CreateTenantAsync(string name, string domain, bool isPaid, string plan);
        Task<Tenant?> GetTenantByDomainAsync(string domain);
        Task<Tenant?> GetTenantByIdAsync(int id);
        Task UpdateTenantPlanAsync(int tenantId, bool isPaid, string plan);
    }

    public class TenantService: ITenantService
    {
        private readonly MrIgorDbContext _context;

        public TenantService(MrIgorDbContext context)
        {
            _context = context;
        }
        public async Task<Tenant> CreateTenantAsync(string name, string domain, bool isPaid, string plan)
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
            return tenant;
        }

        public async Task<Tenant?> GetTenantByDomainAsync(string domain)
        {
            return await _context.Tenants.FirstOrDefaultAsync(t => t.Domain == domain);
        }

        public async Task<Tenant?> GetTenantByIdAsync(int id)
        {
            return await _context.Tenants.FindAsync(id);
        }

        public async Task UpdateTenantPlanAsync(int tenantId, bool isPaid, string plan)
        {
            var tenant = await _context.Tenants.FindAsync(tenantId);
            if (tenant == null) return;

            tenant.IsPaid = isPaid;
            tenant.SubcriptionPlan = plan;

            _context.Tenants.Update(tenant);
            await _context.SaveChangesAsync();
        }
    }
}