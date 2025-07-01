using System;
using System.Collections.Generic;

namespace TyphoonTaskingTool.DTOs
{
    public class LookupRankDTO
    {
        public int RankId { get; set; }

        public string? RankNameLong { get; set; }

        public string? RankNameShort { get; set; }

        public string? RankNatoequiv { get; set; }
    }
}