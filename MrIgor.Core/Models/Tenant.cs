using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Table("Tenants", Schema = "Academic")]
public partial class Tenant
{
    [Key]
    public Guid TenantId { get; set; }

    [StringLength(150)]
    public string Name { get; set; } = null!;

    [StringLength(255)]
    public string? Domain { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsPaid { get; set; }

    [StringLength(50)]
    public string? SubscriptionType { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(100)]
    public string? Country { get; set; }

    [StringLength(100)]
    public string? SchoolType { get; set; }

    [Column("PaymentURL")]
    public string? PaymentUrl { get; set; }

    public string? SubcriptionPlan { get; set; }

    // [InverseProperty("Tenant")]
    public virtual ICollection<AspNetRole> AspNetRoles { get; set; } = new List<AspNetRole>();

    // [InverseProperty("Tenant")]
    public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; } = new List<AspNetUserRole>();

    // [InverseProperty("Tenant")]
    public virtual ICollection<AspNetUser> AspNetUsers { get; set; } = new List<AspNetUser>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    [InverseProperty("Tenant")]
    public virtual ICollection<StudentSubjectApproval> StudentSubjectApprovals { get; set; } = new List<StudentSubjectApproval>();

    [InverseProperty("Tenant")]
    public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();

    [InverseProperty("Tenant")]
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    [InverseProperty("Tenant")]
    public virtual ICollection<TeachersSubject> TeachersSubjects { get; set; } = new List<TeachersSubject>();
}
