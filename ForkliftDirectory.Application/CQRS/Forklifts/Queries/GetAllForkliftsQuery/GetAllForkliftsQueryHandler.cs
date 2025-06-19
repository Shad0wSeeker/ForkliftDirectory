using AutoMapper;
using ForkliftDirectory.Application.DTOs.ForkliftDTOs;
using ForkliftDirectory.Application.Interfaces;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.Forklifts.Queries.GetAllForkliftsQuery
{
    public class GetAllForkliftsQueryHandler : IRequestHandler<GetAllForkliftsQuery, List<ForkliftDto>>
    {
        private readonly IForkliftRepository _repository;
        private readonly IMapper _mapper;

        public GetAllForkliftsQueryHandler(IForkliftRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ForkliftDto>> Handle(GetAllForkliftsQuery request, CancellationToken cancellationToken)
        {
            var forklifts = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<ForkliftDto>>(forklifts);
        }    
    }
}
