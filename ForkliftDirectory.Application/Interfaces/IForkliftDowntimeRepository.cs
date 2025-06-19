using ForkliftDirectory.Domain.Entities;

namespace ForkliftDirectory.Application.Interfaces
{
    public interface IForkliftDowntimeRepository : IBaseRepository<ForkliftDowntime>
    {
        Task<List<ForkliftDowntime>> GetByForkliftIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> HasActiveDowntimesAsync(int forkliftId, CancellationToken cancellationToken);
    }
}
