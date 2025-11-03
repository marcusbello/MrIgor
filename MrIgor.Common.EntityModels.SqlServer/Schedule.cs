using System;
using System.Collections.Generic;

namespace Shared.MrIgor;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int SubjectId { get; set; }

    public int ClassroomId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public byte DayOfWeek { get; set; }

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
