using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using TyphoonTaskingTool.Data;
using TyphoonTaskingTool.Models;

namespace TyphoonTaskingTool.Services
{
    public class GenericLookupService (IDbContextFactory<TmscDbContext> dbFactory) : IGenericLookupService
    {
        public async Task<List<LookupStatus>> GetAllOrderedAsync()
        {
            using var context = dbFactory.CreateDbContext();
            return await context.Set<LookupStatus>()
                .AsNoTracking()
                .Select(s => new LookupStatus
                {
                    StatusId = EF.Property<int>(s, "StatusId"),
                    StatusName = EF.Property<string>(s, "StatusName")
                })
                .OrderBy(s => s.StatusId)
                .ToListAsync();
        }
    }
}
