using System;
using System.Collections.Generic;

namespace Shared.MrIgor;

public partial class StudentSubjectApproval
{
    public int Id { get; set; }

    public string TeacherId { get; set; } = null!;

    public int StudentSubjectId { get; set; }

    public bool Approved { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public virtual StudentSubject StudentSubject { get; set; } = null!;

    public virtual AspNetUser Teacher { get; set; } = null!;
}
