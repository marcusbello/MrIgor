using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Table("Schedules", Schema = "Academic")]
public partial class Schedule
{
    [Key]
    public int ScheduleId { get; set; }

    public int SubjectId { get; set; }

    public int ClassroomId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public byte DayOfWeek { get; set; }

    public Guid TenantId { get; set; }

    [ForeignKey("ClassroomId")]
    [InverseProperty("Schedules")]
    public virtual Classroom Classroom { get; set; } = null!;

    [ForeignKey("SubjectId")]
    [InverseProperty("Schedules")]
    public virtual Subject Subject { get; set; } = null!;

    [ForeignKey("TenantId")]
    [InverseProperty("Schedules")]
    public virtual Tenant Tenant { get; set; } = null!;
}
