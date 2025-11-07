using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Table("Exams", Schema = "Academic")]
public partial class Exam
{
    [Key]
    public int ExamId { get; set; }

    public int SubjectId { get; set; }

    [StringLength(150)]
    public string Title { get; set; } = null!;

    [Column(TypeName = "decimal(5, 2)")]
    public decimal MaxScore { get; set; }

    public DateTime ExamDate { get; set; }

    public Guid TenantId { get; set; }

    [InverseProperty("Exam")]
    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    [ForeignKey("SubjectId")]
    [InverseProperty("Exams")]
    public virtual Subject Subject { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("Exams")]
    public virtual Tenant Tenant { get; set; } = null!;
}
