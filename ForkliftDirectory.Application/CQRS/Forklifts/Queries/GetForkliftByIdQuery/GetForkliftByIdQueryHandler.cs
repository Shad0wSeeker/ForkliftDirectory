using AutoMapper;
using ForkliftDirectory.Application.DTOs.ForkliftDTOs;
using ForkliftDirectory.Application.Interfaces;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.Forklifts.Queries.GetForkliftByIdQuery
{
    public class GetForkliftByIdQueryHandler : IRequestHandler<GetForkliftByIdQuery, ForkliftDto>
    {
        private readonly IForkliftRepository _repository;
        private readonly IMapper _mapper;

        public GetForkliftByIdQueryHandler(IForkliftRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ForkliftDto> Handle(GetForkliftByIdQuery request, CancellationToken cancellationToken)
        {
            var forklift = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (forklift == null)
            {
                throw new Exception("Погрузчик не найден");                
            }

            return _mapper.Map<ForkliftDto>(forklift);
        }
    }
}
