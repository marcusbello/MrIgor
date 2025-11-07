using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[PrimaryKey("UserId", "RoleId")]
[Index("RoleId", Name = "IX_AspNetUserRoles_RoleId")]
public partial class AspNetUserRole
{
    [Key]
    public string UserId { get; set; } = null!;

    [Key]
    public string RoleId { get; set; } = null!;

    public Guid? TenantId { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("AspNetUserRoles")]
    public virtual AspNetRole Role { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("AspNetUserRoles")]
    public virtual Tenant? Tenant { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("AspNetUserRoles")]
    public virtual AspNetUser User { get; set; } = null!;
}
