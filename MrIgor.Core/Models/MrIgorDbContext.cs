using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

public partial class MrIgorDbContext : DbContext
{
    public MrIgorDbContext()
    {
    }

    public MrIgorDbContext(DbContextOptions<MrIgorDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<StudentSubject> StudentSubjects { get; set; }

    public virtual DbSet<StudentSubjectApproval> StudentSubjectApprovals { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<TeachersSubject> TeachersSubjects { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=MrIgorDB;User Id=sa;Password=1234;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.HasOne(d => d.Tenant).WithMany(p => p.AspNetRoles).HasConstraintName("FK_AspNetRoles_Tenant");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.HasOne(d => d.Tenant).WithMany(p => p.AspNetUsers).HasConstraintName("FK_AspNetUsers_Tenant");
        });

        modelBuilder.Entity<AspNetUserRole>(entity =>
        {
            entity.HasOne(d => d.Tenant).WithMany(p => p.AspNetUserRoles).HasConstraintName("FK_AspNetUserRoles_Tenant");
        });

        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.AssessmentId).HasName("PK__Assessme__3D2BF81EDD65C589");

            entity.HasOne(d => d.Subject).WithMany(p => p.Assessments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assessments_Subject");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Assessments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assessments_Tenant");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69261C363C9B7A");

            entity.Property(e => e.AttendedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Classroom).WithMany(p => p.Attendances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Classroom");

            entity.HasOne(d => d.Student).WithMany(p => p.Attendances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Student");

            entity.HasOne(d => d.Subject).WithMany(p => p.Attendances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Subject");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Attendances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Tenant");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.ClassroomId).HasName("PK__Classroo__11618EAAEA32DC3B");

            entity.Property(e => e.Capacity).HasDefaultValue(30);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Classrooms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Classrooms_Tenant");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__Exams__297521C7A36B965C");

            entity.HasOne(d => d.Subject).WithMany(p => p.Exams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exams_Subject");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Exams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exams_Tenant");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E12FE7BBADC");

            entity.Property(e => e.SentAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Recipient).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifications_Recipient");

            entity.HasOne(d => d.Subject).WithMany(p => p.Notifications).HasConstraintName("FK_Notifications_Subject");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifications_Tenant");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B49821B2F9C");

            entity.HasOne(d => d.Classroom).WithMany(p => p.Schedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedules_Classroom");

            entity.HasOne(d => d.Subject).WithMany(p => p.Schedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedules_Subject");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Schedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedules_Tenant");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.HasKey(e => e.ScoreId).HasName("PK__Scores__7DD229D18032CA2C");

            entity.Property(e => e.RecordedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Assessment).WithMany(p => p.Scores).HasConstraintName("FK_Scores_Assessment");

            entity.HasOne(d => d.Exam).WithMany(p => p.Scores).HasConstraintName("FK_Scores_Exam");

            entity.HasOne(d => d.Student).WithMany(p => p.Scores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scores_Student");

            entity.HasOne(d => d.Subject).WithMany(p => p.Scores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scores_Subject");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Scores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scores_Tenant");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__Sessions__C9F492902F42498B");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Tenant).WithMany(p => p.Sessions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sessions_Tenant");
        });

        modelBuilder.Entity<StudentSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentS__3214EC072CD4AF8B");

            entity.Property(e => e.RegisteredAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentSubjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentSubjects_Student");

            entity.HasOne(d => d.Subject).WithMany(p => p.StudentSubjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentSubjects_Subject");

            entity.HasOne(d => d.Tenant).WithMany(p => p.StudentSubjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentSubjects_Tenant");
        });

        modelBuilder.Entity<StudentSubjectApproval>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentS__3214EC071B055513");

            entity.HasOne(d => d.StudentSubject).WithMany(p => p.StudentSubjectApprovals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Approvals_StudentSubject");

            entity.HasOne(d => d.Teacher).WithMany(p => p.StudentSubjectApprovals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Approvals_Teacher");

            entity.HasOne(d => d.Tenant).WithMany(p => p.StudentSubjectApprovals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Approvals_Tenant");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA3A80BC4A452");

            entity.HasOne(d => d.Classroom).WithMany(p => p.Subjects).HasConstraintName("FK_Subjects_Classroom");

            entity.HasOne(d => d.Session).WithMany(p => p.Subjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subjects_Session");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Subjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subjects_Tenant");
        });

        modelBuilder.Entity<TeachersSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teachers__3214EC07B62212B0");

            entity.Property(e => e.AssignedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeachersSubjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeachersSubjects_Subject");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeachersSubjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeachersSubjects_Teacher");

            entity.HasOne(d => d.Tenant).WithMany(p => p.TeachersSubjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeachersSubjects_Tenant");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(e => e.TenantId).HasName("PK__Tenants__2E9B47E170819AFD");

            entity.Property(e => e.TenantId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
