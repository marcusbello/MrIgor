using System;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using MrIgor.Mvc.Authorization.Requirements;

namespace MrIgor.Mvc.Authorization.Handlers;

public class TenantRequirementHandler : AuthorizationHandler<TenantRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        TenantRequirement requirement)
    {
        var userTenantId = context.User.FindFirst("tenantId")?.Value;

        // USER MUST HAVE TENANT
        if (string.IsNullOrWhiteSpace(userTenantId))
            return Task.CompletedTask;


        // USER MUST HAVE ONE OF THE ALLOWED ROLES
        var hasAllowedRole = requirement.AllowedRoles
            .Any(role => context.User.IsInRole(role));

        if (!hasAllowedRole)
            return Task.CompletedTask;

        // Success
        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}
