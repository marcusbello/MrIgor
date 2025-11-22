using System;
using Microsoft.AspNetCore.Authorization;

namespace MrIgor.Mvc.Authorization.Requirements;

public class TenantRequirement : IAuthorizationRequirement
{
    public string[] AllowedRoles { get; }

    public TenantRequirement(params string[] allowedRoles)
    {
        AllowedRoles = allowedRoles;
    }
}
