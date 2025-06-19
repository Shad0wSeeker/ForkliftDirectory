using AutoMapper;
using ForkliftDirectory.Application.DTOs.ForkliftDowntimeDTOs;
using ForkliftDirectory.Application.Interfaces;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.ForkliftDowntime.Queries.GetDowntimesByForkliftIdQuery
{
    public class GetDowntimesByForkliftIdQueryHandler : IRequestHandler<GetDowntimesByForkliftIdQuery, List<ForkliftDowntimeDto>>
    {
        private readonly IForkliftDowntimeRepository _repository;
        private readonly IMapper _mapper;

        public GetDowntimesByForkliftIdQueryHandler(IForkliftDowntimeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ForkliftDowntimeDto>> Handle(GetDowntimesByForkliftIdQuery request, CancellationToken cancellationToken)
        {
            var downtimes = await _repository.GetByForkliftIdAsync(request.ForkliftId, cancellationToken);
            return _mapper.Map<List<ForkliftDowntimeDto>>(downtimes);
        }
    }
}
