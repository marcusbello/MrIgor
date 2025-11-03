using System;
using System.Collections.Generic;

namespace Shared.MrIgor;

public partial class StudentSubject
{
    public int Id { get; set; }

    public string StudentId { get; set; } = null!;

    public int SubjectId { get; set; }

    public DateTime? RegisteredAt { get; set; }

    public virtual AspNetUser Student { get; set; } = null!;

    public virtual ICollection<StudentSubjectApproval> StudentSubjectApprovals { get; set; } = new List<StudentSubjectApproval>();

    public virtual Subject Subject { get; set; } = null!;
}
