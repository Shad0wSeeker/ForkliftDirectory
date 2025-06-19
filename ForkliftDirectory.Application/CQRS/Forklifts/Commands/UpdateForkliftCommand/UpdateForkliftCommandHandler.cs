using AutoMapper;
using ForkliftDirectory.Application.Interfaces;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.Forklifts.Commands.UpdateForkliftCommand
{
    public class UpdateForkliftCommandHandler : IRequestHandler<UpdateForkliftCommand, bool>
    {
        private readonly IForkliftRepository _repository;
        private readonly IMapper _mapper;

        public UpdateForkliftCommandHandler(IForkliftRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateForkliftCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken)
                         ?? throw new KeyNotFoundException($"Погрузчик с ID {request.Id} не найден");

            _mapper.Map(request.Dto, entity);
            entity.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(entity, cancellationToken);
            return true;
        }
    }
}
