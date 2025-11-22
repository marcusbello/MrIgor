using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[PrimaryKey("LoginProvider", "ProviderKey")]
[Index("UserId", Name = "IX_AspNetUserLogins_UserId")]
public partial class AspNetUserLogin : IdentityUserLogin<string>
{
    // [ForeignKey("UserId")]
    // [InverseProperty("AspNetUserLogins")]
    // public virtual AspNetUser User { get; set; } = null!;
}
