using ForkliftDirectory.Domain.Entities;

namespace ForkliftDirectory.Application.Interfaces
{
    public interface IForkliftRepository : IBaseRepository<Forklift>
    {
        Task<List<Forklift>> SearchByNumberAsync(string partialNumber, CancellationToken cancellationToken);
        Task<bool> HasDowntimesAsync(int forkliftId, CancellationToken cancellationToken);
        Task UpdateActiveStatusAsync(int forkliftId, bool isActive, string updatedBy, CancellationToken cancellationToken);
    }
}
