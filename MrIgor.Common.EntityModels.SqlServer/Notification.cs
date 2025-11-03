using System;
using System.Collections.Generic;

namespace Shared.MrIgor;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string RecipientId { get; set; } = null!;

    public int? SubjectId { get; set; }

    public string Message { get; set; } = null!;

    public bool IsRead { get; set; }

    public DateTime? SentAt { get; set; }

    public virtual AspNetUser Recipient { get; set; } = null!;

    public virtual Subject? Subject { get; set; }
}
