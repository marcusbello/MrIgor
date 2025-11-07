using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Table("TeachersSubjects", Schema = "Academic")]
[Index("TeacherId", "SubjectId", Name = "UQ_Teacher_Subject", IsUnique = true)]
public partial class TeachersSubject
{
    [Key]
    public int Id { get; set; }

    public string TeacherId { get; set; } = null!;

    public int SubjectId { get; set; }

    public DateTime? AssignedAt { get; set; }

    public Guid TenantId { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("TeachersSubjects")]
    public virtual Subject Subject { get; set; } = null!;

    [ForeignKey("TeacherId")]
    [InverseProperty("TeachersSubjects")]
    public virtual AspNetUser Teacher { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("TeachersSubjects")]
    public virtual Tenant Tenant { get; set; } = null!;
}
