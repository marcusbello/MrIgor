using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Index("UserId", Name = "IX_AspNetUserClaims_UserId")]
public partial class AspNetUserClaim : IdentityUserClaim<string>
{
}
