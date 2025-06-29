using System;
using System.Collections.Generic;

namespace TyphoonTaskingTool.Models;

public partial class RequestUpdate
{
    public Guid UpdateId { get; set; }

    public Guid RequestTaskId { get; set; }

    public DateTime? UpdateTimeStamp { get; set; }

    public string? UpdateDescription { get; set; }

    public string? UpdateBy { get; set; }

    public int? StatusId { get; set; }

    public virtual Request RequestTask { get; set; } = null!;

    public virtual LookupStatus? Status { get; set; }
}
