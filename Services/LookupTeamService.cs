using Microsoft.EntityFrameworkCore;
using TyphoonTaskingTool.Data;
using TyphoonTaskingTool.DTOs;

namespace TyphoonTaskingTool.Services
{
    public class LookupTeamService(IDbContextFactory<TmscDbContext> dbFactory) : ILookupTeamService
    {
        public async Task<List<LookupTeamDTO>> GetAllOrderedAsync()
        {
            using var context = dbFactory.CreateDbContext();
            return await context.LookupTeams
                .AsNoTracking()
                .Select(u => new LookupTeamDTO
                {
                    TeamId = u.TeamId,
                    TeamNameLong = u.TeamNameLong,
                    TeamNameShort = u.TeamNameShort,
                })
                .OrderBy(r => r.TeamId)
                .ToListAsync();
        }
    }
}
