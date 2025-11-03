using System;
using System.Collections.Generic;

namespace Shared.MrIgor;

public partial class TeachersSubject
{
    public int Id { get; set; }

    public string TeacherId { get; set; } = null!;

    public int SubjectId { get; set; }

    public DateTime? AssignedAt { get; set; }

    public virtual Subject Subject { get; set; } = null!;

    public virtual AspNetUser Teacher { get; set; } = null!;
}
