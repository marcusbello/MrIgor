using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

public partial class AspNetRole : IdentityRole
{
    public Guid? TenantId { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; } = new List<AspNetRoleClaim>();

    [InverseProperty("Role")]
    public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; } = new List<AspNetUserRole>();

    [ForeignKey("TenantId")]
    [InverseProperty("AspNetRoles")]
    public virtual Tenant? Tenant { get; set; }
}
