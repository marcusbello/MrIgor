using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MrIgor.Core.Models;

[Table("Notifications", Schema = "Academic")]
public partial class Notification
{
    [Key]
    public int NotificationId { get; set; }

    [StringLength(450)]
    public string RecipientId { get; set; } = null!;

    public int? SubjectId { get; set; }

    [StringLength(500)]
    public string Message { get; set; } = null!;

    public bool IsRead { get; set; }

    public DateTime? SentAt { get; set; }

    public Guid TenantId { get; set; }

    [ForeignKey("RecipientId")]
    [InverseProperty("Notifications")]
    public virtual AspNetUser Recipient { get; set; } = null!;

    [ForeignKey("SubjectId")]
    [InverseProperty("Notifications")]
    public virtual Subject? Subject { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("Notifications")]
    public virtual Tenant Tenant { get; set; } = null!;
}
