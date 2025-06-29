using System;
using System.Collections.Generic;

namespace TyphoonTaskingTool.Models;

public partial class LookupUnit
{
    public int UnitId { get; set; }

    public string? UnitNameLong { get; set; }

    public string? UnitNameShort { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
