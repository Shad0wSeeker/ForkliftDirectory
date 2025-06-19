using AutoMapper;
using ForkliftDirectory.Application.Interfaces;
using ForkliftDirectory.Domain.Entities;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.Forklifts.Commands.CreateForkliftCommand
{
    public class CreateForkliftCommandHandler : IRequestHandler<CreateForkliftCommand, int>
    {
        private readonly IForkliftRepository _repository;
        private readonly IMapper _mapper;

        public CreateForkliftCommandHandler(IForkliftRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateForkliftCommand request, CancellationToken cancellationToken)
        {
            var forklift = _mapper.Map<Forklift>(request.Dto);
            forklift.UpdatedAt = DateTime.UtcNow;
            var result = await _repository.AddAsync(forklift, cancellationToken);
            return result.Id;
        }
    }
}
