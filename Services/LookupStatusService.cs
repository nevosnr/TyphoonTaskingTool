using Microsoft.EntityFrameworkCore;
using TyphoonTaskingTool.Data;
using TyphoonTaskingTool.DTOs;

namespace TyphoonTaskingTool.Services
{
    public class LookupStatusService(IDbContextFactory<TmscDbContext> dbFactory) : ILookupStatusService
    {
        public async Task<List<LookupStatusDTO>> GetAllOrderedAsync()
        {
            using var context = dbFactory.CreateDbContext();
            return await context.LookupStatuses
                .AsNoTracking()
                .Select(u => new LookupStatusDTO
                {
                    StatusId = u.StatusId,
                    StatusName = u.StatusName,
                    StatusDescription = u.StatusDescription,
                })
                .OrderBy(r => r.StatusId)
                .ToListAsync();
        }
    }
}
