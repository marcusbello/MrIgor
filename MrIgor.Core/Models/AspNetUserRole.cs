using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[PrimaryKey("UserId", "RoleId")]
[Index("RoleId", Name = "IX_AspNetUserRoles_RoleId")]
public partial class AspNetUserRole : IdentityUserRole<string>
{
    public Guid? TenantId { get; set; }

    [ForeignKey("TenantId")]
    public virtual Tenant? Tenant { get; set; }
}
