using ForkliftDirectory.Application.Interfaces;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.Forklifts.Commands.DeleteForkliftCommand
{
    public class DeleteForkliftCommandHandler : IRequestHandler<DeleteForkliftCommand, bool>
    {
        private readonly IForkliftRepository _repository;

        public DeleteForkliftCommandHandler(IForkliftRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteForkliftCommand request, CancellationToken cancellationToken)
        {
            var forklift = await _repository.GetByIdAsync(request.Id, cancellationToken)
               ?? throw new KeyNotFoundException("Погрузчик не найден");

            var forkliftDowntime = await _repository.GetByIdAsync(request.Id, cancellationToken)
               ?? throw new KeyNotFoundException("Простой погрузчика не найден");

            var hasDowntimes = await _repository.HasDowntimesAsync(request.Id, cancellationToken);
            if (hasDowntimes)
                throw new InvalidOperationException("Невозможно удалить погрузчик с зарегистрированным простоем");

            await _repository.DeleteAsync(request.Id, cancellationToken);
            return true;
        }
    }
}
