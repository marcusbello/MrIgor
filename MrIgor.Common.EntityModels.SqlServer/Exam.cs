using System;
using System.Collections.Generic;

namespace Shared.MrIgor;

public partial class Exam
{
    public int ExamId { get; set; }

    public int SubjectId { get; set; }

    public string Title { get; set; } = null!;

    public decimal MaxScore { get; set; }

    public DateTime ExamDate { get; set; }

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    public virtual Subject Subject { get; set; } = null!;
}
