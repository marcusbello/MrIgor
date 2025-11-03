using System;
using System.Collections.Generic;

namespace Shared.MrIgor;

public partial class Session
{
    public int SessionId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
