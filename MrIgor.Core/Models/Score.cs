using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Table("Scores", Schema = "Academic")]
public partial class Score
{
    [Key]
    public int ScoreId { get; set; }

    [StringLength(450)]
    public string StudentId { get; set; } = null!;

    public int SubjectId { get; set; }

    public int? AssessmentId { get; set; }

    public int? ExamId { get; set; }

    [Column("Score", TypeName = "decimal(5, 2)")]
    public decimal Score1 { get; set; }

    public DateTime? RecordedAt { get; set; }

    public Guid TenantId { get; set; }

    [ForeignKey("AssessmentId")]
    [InverseProperty("Scores")]
    public virtual Assessment? Assessment { get; set; }

    [ForeignKey("ExamId")]
    [InverseProperty("Scores")]
    public virtual Exam? Exam { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Scores")]
    public virtual AspNetUser Student { get; set; } = null!;

    [ForeignKey("SubjectId")]
    [InverseProperty("Scores")]
    public virtual Subject Subject { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("Scores")]
    public virtual Tenant Tenant { get; set; } = null!;
}
