using AutoMapper;
using ForkliftDirectory.Application.Interfaces;
using MediatR;

namespace ForkliftDirectory.Application.CQRS.ForkliftDowntime.Commands.UpdateForkliftDowntimeCommand
{
    public class UpdateForkliftDowntimeCommandHandler : IRequestHandler<UpdateForkliftDowntimeCommand, bool>
    {
        private readonly IForkliftDowntimeRepository _repository;
        private readonly IMapper _mapper;

        public UpdateForkliftDowntimeCommandHandler(IForkliftDowntimeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateForkliftDowntimeCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.ExistsAsync(request.Id, cancellationToken);
            if (!exists)
                return false;

            var entity = _mapper.Map<Domain.Entities.ForkliftDowntime>(request.Dto);
            entity.Id = request.Id;

            await _repository.UpdateAsync(entity, cancellationToken);
            return true;
        }       
    }
}
