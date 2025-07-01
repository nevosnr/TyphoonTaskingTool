using TyphoonTaskingTool.DTOs;

namespace TyphoonTaskingTool.Services
{
    public interface ILookupRankService
    {
        Task<List<LookupRankDTO>> GetAllOrderedAsync();
    }
}
