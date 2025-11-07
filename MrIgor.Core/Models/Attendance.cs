using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Table("Attendance", Schema = "Academic")]
public partial class Attendance
{
    [Key]
    public int AttendanceId { get; set; }

    public int SubjectId { get; set; }

    [StringLength(450)]
    public string StudentId { get; set; } = null!;

    public int ClassroomId { get; set; }

    public DateTime? AttendedAt { get; set; }

    public Guid TenantId { get; set; }

    [ForeignKey("ClassroomId")]
    [InverseProperty("Attendances")]
    public virtual Classroom Classroom { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("Attendances")]
    public virtual AspNetUser Student { get; set; } = null!;

    [ForeignKey("SubjectId")]
    [InverseProperty("Attendances")]
    public virtual Subject Subject { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("Attendances")]
    public virtual Tenant Tenant { get; set; } = null!;
}
