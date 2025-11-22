using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Index("RoleId", Name = "IX_AspNetRoleClaims_RoleId")]
public partial class AspNetRoleClaim : IdentityRoleClaim<string>
{
    // [ForeignKey("RoleId")]
    // [InverseProperty("AspNetRoleClaims")]
    // public virtual AspNetRole Role { get; set; } = null!;
}
