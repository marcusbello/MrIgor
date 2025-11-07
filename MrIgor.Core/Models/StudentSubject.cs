using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Table("StudentSubjects", Schema = "Academic")]
[Index("StudentId", "SubjectId", Name = "UQ_Student_Subject", IsUnique = true)]
public partial class StudentSubject
{
    [Key]
    public int Id { get; set; }

    public string StudentId { get; set; } = null!;

    public int SubjectId { get; set; }

    public DateTime? RegisteredAt { get; set; }

    public Guid TenantId { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("StudentSubjects")]
    public virtual AspNetUser Student { get; set; } = null!;

    [InverseProperty("StudentSubject")]
    public virtual ICollection<StudentSubjectApproval> StudentSubjectApprovals { get; set; } = new List<StudentSubjectApproval>();

    [ForeignKey("SubjectId")]
    [InverseProperty("StudentSubjects")]
    public virtual Subject Subject { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("StudentSubjects")]
    public virtual Tenant Tenant { get; set; } = null!;
}
