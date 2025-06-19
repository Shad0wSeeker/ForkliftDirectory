using ForkliftDirectory.Application.Interfaces;
using ForkliftDirectory.Domain.Entities;
using ForkliftDirectory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ForkliftDirectory.Infrastructure.Repositories
{
    public class ForkliftDowntimeRepository : BaseRepository<ForkliftDowntime>, IForkliftDowntimeRepository
    {
        public ForkliftDowntimeRepository(ApplicationDbContext context) : base(context, context.ForkliftDowntimes) { }

        public async Task<List<ForkliftDowntime>> GetByForkliftIdAsync(int forkliftId, CancellationToken cancellationToken)
        {
            return await _dbSet
                .Where(d => d.ForkliftId == forkliftId)
                .OrderByDescending(d => d.StartTime)
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> HasActiveDowntimesAsync(int forkliftId, CancellationToken cancellationToken)
        {
            return await _dbSet
                .AnyAsync(d => d.ForkliftId == forkliftId && d.EndTime == null,
                         cancellationToken);
        }

        public override async Task<ForkliftDowntime> AddAsync(ForkliftDowntime entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            if (entity.EndTime == null)
            {
                await UpdateForkliftActiveStatus(entity.ForkliftId, false, cancellationToken);
            }

            return entity;
        }

        public override async Task<ForkliftDowntime> UpdateAsync(ForkliftDowntime entity, CancellationToken cancellationToken)
        {
            var existingEntity = await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == entity.Id, cancellationToken);

            // Обновляем запись
            _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            // Проверяем изменение EndTime
            if (existingEntity != null && existingEntity.EndTime != entity.EndTime)
            {
                await UpdateForkliftStatusBasedOnDowntimes(entity.ForkliftId, cancellationToken);
            }

            return entity;
        }

        public override async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _dbSet.FindAsync(new object[] { id }, cancellationToken);
            if (entity == null) return;

            var forkliftId = entity.ForkliftId;
            var wasActive = entity.EndTime == null;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            // Если удалили активный простой, проверяем статус погрузчика
            if (wasActive)
            {
                await UpdateForkliftStatusBasedOnDowntimes(forkliftId, cancellationToken);
            }
        }

        private async Task UpdateForkliftStatusBasedOnDowntimes(int forkliftId, CancellationToken cancellationToken)
        {
            var hasActiveDowntimes = await _dbSet
                .AnyAsync(d => d.ForkliftId == forkliftId && d.EndTime == null,
                         cancellationToken);

            await UpdateForkliftActiveStatus(forkliftId, !hasActiveDowntimes, cancellationToken);
        }

        private async Task UpdateForkliftActiveStatus(int forkliftId, bool isActive, CancellationToken cancellationToken)
        {
            var forklift = await _context.Forklifts.FindAsync(new object[] { forkliftId }, cancellationToken);
            if (forklift != null && forklift.isActive != isActive)
            {
                forklift.isActive = isActive;
                forklift.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
