using TyphoonTaskingTool.Models;

namespace TyphoonTaskingTool.Services
{
    public interface IGenericLookupService
    {
        Task<List<LookupStatus>> GetAllOrderedAsync();
    }
}
