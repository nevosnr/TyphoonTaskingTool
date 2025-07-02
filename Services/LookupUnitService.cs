using Microsoft.EntityFrameworkCore;
using TyphoonTaskingTool.Data;
using TyphoonTaskingTool.DTOs;

namespace TyphoonTaskingTool.Services
{
    public class LookupUnitService(IDbContextFactory<TmscDbContext> dbFactory) : ILookupUnitService
{
        public async Task<List<LookupUnitDTO>> GetAllOrderedAsync()
        {
            using var context = dbFactory.CreateDbContext();
            return await context.LookupUnits
                .AsNoTracking()
                .Select(u => new LookupUnitDTO
                {
                    UnitId = u.UnitId,
                    UnitNameLong = u.UnitNameLong,
                    UnitNameShort = u.UnitNameShort,
                })
                .OrderBy(r => r.UnitId)
                .ToListAsync();
        }
    }

}
