using ForkliftDirectory.Application.Interfaces;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.ForkliftDowntime.Commands.DeleteForkliftDowntimeCommand
{
    public class DeleteForkliftDowntimeCommandHandler : IRequestHandler<DeleteForkliftDowntimeCommand, bool>
    {
        private readonly IForkliftDowntimeRepository _repository;

        public DeleteForkliftDowntimeCommandHandler(IForkliftDowntimeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteForkliftDowntimeCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.ExistsAsync(request.Id, cancellationToken);
            if (!exists) 
                return false;

            await _repository.DeleteAsync(request.Id, cancellationToken);
            return true;
        }
    }
}
