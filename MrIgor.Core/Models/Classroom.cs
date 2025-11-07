using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Table("Classrooms", Schema = "Academic")]
public partial class Classroom
{
    [Key]
    public int ClassroomId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    [StringLength(255)]
    public string? Location { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid TenantId { get; set; }

    [InverseProperty("Classroom")]
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    [InverseProperty("Classroom")]
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    [InverseProperty("Classroom")]
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    [ForeignKey("TenantId")]
    [InverseProperty("Classrooms")]
    public virtual Tenant Tenant { get; set; } = null!;
}
