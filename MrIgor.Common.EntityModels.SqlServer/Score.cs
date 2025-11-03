using System;
using System.Collections.Generic;

namespace Shared.MrIgor;

public partial class Score
{
    public int ScoreId { get; set; }

    public string StudentId { get; set; } = null!;

    public int SubjectId { get; set; }

    public int? AssessmentId { get; set; }

    public int? ExamId { get; set; }

    public decimal Score1 { get; set; }

    public DateTime? RecordedAt { get; set; }

    public virtual Assessment? Assessment { get; set; }

    public virtual Exam? Exam { get; set; }

    public virtual AspNetUser Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
