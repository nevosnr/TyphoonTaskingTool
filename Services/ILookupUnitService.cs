using TyphoonTaskingTool.DTOs;

namespace TyphoonTaskingTool.Services
{
    public interface ILookupUnitService
    {
        Task<List<LookupUnitDTO>> GetAllOrderedAsync();
    }
}