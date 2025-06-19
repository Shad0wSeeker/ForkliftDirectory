using ForkliftDirectory.Application.DTOs.ForkliftDTOs;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.Forklifts.Queries.SearchByNumberQuery
{
    public class SearchByNumberQuery : IRequest<List<ForkliftDto>>
    {
        public string? Number { get; }

        public SearchByNumberQuery(string? number)
        {
            Number = number;
        }
    }
}
