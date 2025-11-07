using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Table("StudentSubjectApprovals", Schema = "Academic")]
public partial class StudentSubjectApproval
{
    [Key]
    public int Id { get; set; }

    [StringLength(450)]
    public string TeacherId { get; set; } = null!;

    public int StudentSubjectId { get; set; }

    public bool Approved { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public Guid TenantId { get; set; }

    [ForeignKey("StudentSubjectId")]
    [InverseProperty("StudentSubjectApprovals")]
    public virtual StudentSubject StudentSubject { get; set; } = null!;

    [ForeignKey("TeacherId")]
    [InverseProperty("StudentSubjectApprovals")]
    public virtual AspNetUser Teacher { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("StudentSubjectApprovals")]
    public virtual Tenant Tenant { get; set; } = null!;
}
