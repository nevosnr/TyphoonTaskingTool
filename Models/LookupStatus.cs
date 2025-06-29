using System;
using System.Collections.Generic;

namespace TyphoonTaskingTool.Models;

public partial class LookupStatus
{
    public int StatusId { get; set; }

    public string? StatusName { get; set; }

    public string? StatusDescription { get; set; }

    public virtual ICollection<RequestUpdate> RequestUpdates { get; set; } = new List<RequestUpdate>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
