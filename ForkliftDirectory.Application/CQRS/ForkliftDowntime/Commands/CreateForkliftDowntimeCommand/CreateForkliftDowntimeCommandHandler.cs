using AutoMapper;
using ForkliftDirectory.Application.Interfaces;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.ForkliftDowntime.Commands.CreateForkliftDowntimeCommand
{
    public class CreateForkliftDowntimeCommandHandler : IRequestHandler<CreateForkliftDowntimeCommand, int>
    {
        private readonly IForkliftDowntimeRepository _repository;
        private readonly IMapper _mapper;

        public CreateForkliftDowntimeCommandHandler(IForkliftDowntimeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateForkliftDowntimeCommand request, CancellationToken cancellationToken)
        {
            var forkliftDowntime = _mapper.Map<Domain.Entities.ForkliftDowntime>(request.Dto);
            var result = await _repository.AddAsync(forkliftDowntime, cancellationToken);
            return result.Id;
        }
    }
}
