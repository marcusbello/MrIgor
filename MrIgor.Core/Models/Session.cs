using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Table("Sessions", Schema = "Academic")]
public partial class Session
{
    [Key]
    public int SessionId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid TenantId { get; set; }

    [InverseProperty("Session")]
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    [ForeignKey("TenantId")]
    [InverseProperty("Sessions")]
    public virtual Tenant Tenant { get; set; } = null!;
}
