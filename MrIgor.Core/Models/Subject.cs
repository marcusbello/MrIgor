using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Table("Subjects", Schema = "Academic")]
public partial class Subject
{
    [Key]
    public int SubjectId { get; set; }

    [StringLength(150)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    public int SessionId { get; set; }

    public int? ClassroomId { get; set; }

    public Guid TenantId { get; set; }

    [InverseProperty("Subject")]
    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    [InverseProperty("Subject")]
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    [ForeignKey("ClassroomId")]
    [InverseProperty("Subjects")]
    public virtual Classroom? Classroom { get; set; }

    [InverseProperty("Subject")]
    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    [InverseProperty("Subject")]
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    [InverseProperty("Subject")]
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    [InverseProperty("Subject")]
    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    [ForeignKey("SessionId")]
    [InverseProperty("Subjects")]
    public virtual Session Session { get; set; } = null!;

    [InverseProperty("Subject")]
    public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();

    [InverseProperty("Subject")]
    public virtual ICollection<TeachersSubject> TeachersSubjects { get; set; } = new List<TeachersSubject>();

    [ForeignKey("TenantId")]
    [InverseProperty("Subjects")]
    public virtual Tenant Tenant { get; set; } = null!;
}
