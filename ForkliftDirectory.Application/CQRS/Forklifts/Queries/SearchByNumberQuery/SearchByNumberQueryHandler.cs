using AutoMapper;
using ForkliftDirectory.Application.DTOs.ForkliftDTOs;
using ForkliftDirectory.Application.Interfaces;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.Forklifts.Queries.SearchByNumberQuery
{
    public class SearchByNumberQueryHandler : IRequestHandler<SearchByNumberQuery, List<ForkliftDto>>
    {
        private readonly IForkliftRepository _repository;
        private readonly IMapper _mapper;

        public SearchByNumberQueryHandler(IForkliftRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ForkliftDto>> Handle(SearchByNumberQuery request, CancellationToken cancellationToken)
        {
            var all = await _repository.GetAllAsync(cancellationToken);

            var filtered = string.IsNullOrWhiteSpace(request.Number)
                ? all
                : all.Where(f => f.Number.Contains(request.Number, StringComparison.OrdinalIgnoreCase)).ToList();

            return _mapper.Map<List<ForkliftDto>>(filtered);
        }
    }
}
