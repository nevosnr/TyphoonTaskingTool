using Microsoft.EntityFrameworkCore;
using TyphoonTaskingTool.Data;
using TyphoonTaskingTool.DTOs;

namespace TyphoonTaskingTool.Services
{
    public class LookupRankService (IDbContextFactory<TmscDbContext> dbFactory) : ILookupRankService
    {
        public async Task<List<LookupRankDTO>> GetAllOrderedAsync()
        {
            using var context = dbFactory.CreateDbContext();
            return await context.LookupRanks
                .AsNoTracking()
                .Select(r => new LookupRankDTO
                {
                    RankId = r.RankId,
                    RankNameLong = r.RankNameLong,
                    RankNameShort = r.RankNameShort,
                    RankNatoequiv = r.RankNatoequiv,
                })
                .OrderBy(r => r.RankId)
                .ToListAsync();
        }
    }
}
