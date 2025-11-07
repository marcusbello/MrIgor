using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Table("Assessments", Schema = "Academic")]
public partial class Assessment
{
    [Key]
    public int AssessmentId { get; set; }

    public int SubjectId { get; set; }

    [StringLength(150)]
    public string Title { get; set; } = null!;

    [Column(TypeName = "decimal(5, 2)")]
    public decimal MaxScore { get; set; }

    public DateTime? DueDate { get; set; }

    public Guid TenantId { get; set; }

    [InverseProperty("Assessment")]
    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    [ForeignKey("SubjectId")]
    [InverseProperty("Assessments")]
    public virtual Subject Subject { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("Assessments")]
    public virtual Tenant Tenant { get; set; } = null!;
}
