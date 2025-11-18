using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Index("NormalizedEmail", Name = "EmailIndex")]
public partial class AspNetUser : IdentityUser
{
    public Guid? TenantId { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    [InverseProperty("User")]
    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    [InverseProperty("User")]
    public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; } = new List<AspNetUserRole>();

    [InverseProperty("User")]
    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; } = new List<AspNetUserToken>();

    [InverseProperty("Student")]
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    [InverseProperty("Recipient")]
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    [InverseProperty("Student")]
    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    [InverseProperty("Teacher")]
    public virtual ICollection<StudentSubjectApproval> StudentSubjectApprovals { get; set; } = new List<StudentSubjectApproval>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();

    [InverseProperty("Teacher")]
    public virtual ICollection<TeachersSubject> TeachersSubjects { get; set; } = new List<TeachersSubject>();

    [ForeignKey("TenantId")]
    [InverseProperty("AspNetUsers")]
    public virtual Tenant? Tenant { get; set; }
}
