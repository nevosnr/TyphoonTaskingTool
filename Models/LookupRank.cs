﻿using System;
using System.Collections.Generic;

namespace TyphoonTaskingTool.Models;

public partial class LookupRank
{
    public int RankId { get; set; }

    public string? RankNameLong { get; set; }

    public string? RankNameShort { get; set; }

    public string? RankNatoequiv { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
