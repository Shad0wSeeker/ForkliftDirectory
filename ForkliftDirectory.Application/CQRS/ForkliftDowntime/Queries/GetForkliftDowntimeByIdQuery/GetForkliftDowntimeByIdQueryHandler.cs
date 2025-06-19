using AutoMapper;
using ForkliftDirectory.Application.DTOs.ForkliftDowntimeDTOs;
using ForkliftDirectory.Application.Interfaces;
using MediatR;

namespace ForkliftDirectory.Application.CQRS.ForkliftDowntime.Queries.GetForkliftDowntimeByIdQuery
{
    public class GetForkliftDowntimeByIdQueryHandler : IRequestHandler<GetForkliftDowntimeByIdQuery, ForkliftDowntimeDto>
    {
        private readonly IForkliftDowntimeRepository _repository;
        private readonly IMapper _mapper;

        public GetForkliftDowntimeByIdQueryHandler(IForkliftDowntimeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ForkliftDowntimeDto> Handle(GetForkliftDowntimeByIdQuery request, CancellationToken cancellationToken)
        {
            var forkliftDowntime = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (forkliftDowntime == null)
            {
                throw new Exception("Простой не найден");
            }

            return _mapper.Map<ForkliftDowntimeDto>(forkliftDowntime);
        }
    }
}
