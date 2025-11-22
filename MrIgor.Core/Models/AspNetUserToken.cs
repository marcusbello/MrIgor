using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[PrimaryKey("UserId", "LoginProvider", "Name")]
public partial class AspNetUserToken : IdentityUserToken<string>
{
}
