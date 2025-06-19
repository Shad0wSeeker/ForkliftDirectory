using ForkliftDirectory.Application.Interfaces;
using ForkliftDirectory.Domain.Entities;
using ForkliftDirectory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ForkliftDirectory.Infrastructure.Repositories
{
    public class ForkliftRepository : BaseRepository<Forklift>, IForkliftRepository
    {
        public ForkliftRepository(ApplicationDbContext context) : base(context, context.Forklifts) { }
        public async Task<List<Forklift>> SearchByNumberAsync(string partialNumber, CancellationToken cancellationToken)
        {
            return await _dbSet
                .Where(f => f.Number.ToLower().Contains(partialNumber.ToLower()))
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> HasDowntimesAsync(int forkliftId, CancellationToken cancellationToken)
        {
            return await _context.ForkliftDowntimes
                .AnyAsync(d => d.ForkliftId == forkliftId, cancellationToken);
        }

        public async Task UpdateActiveStatusAsync(int forkliftId, bool isActive, string updatedBy, CancellationToken cancellationToken)
        {
            var forklift = await _dbSet.FindAsync(new object[] { forkliftId }, cancellationToken);
            if (forklift != null)
            {
                forklift.isActive = isActive;
                forklift.UpdatedAt = DateTime.UtcNow;
                forklift.UpdatedBy = updatedBy;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
