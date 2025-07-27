using TyphoonTaskingTool.DTOs;

namespace TyphoonTaskingTool.Services
{
    public interface ILookupStatusService
    {
        Task<List<LookupStatusDTO>> GetAllOrderedAsync();
    }
}