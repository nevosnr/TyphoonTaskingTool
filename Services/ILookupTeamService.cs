using TyphoonTaskingTool.DTOs;

namespace TyphoonTaskingTool.Services
{
    public interface ILookupTeamService
    {
        Task<List<LookupTeamDTO>> GetAllOrderedAsync();
    }
}