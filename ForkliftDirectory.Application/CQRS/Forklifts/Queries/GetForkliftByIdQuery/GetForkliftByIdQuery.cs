using ForkliftDirectory.Application.DTOs.ForkliftDTOs;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.Forklifts.Queries.GetForkliftByIdQuery
{
    public class GetForkliftByIdQuery : IRequest<ForkliftDto>
    {
        public int Id { get; }

        public GetForkliftByIdQuery(int id)
        {
            Id = id;
        }
    }
}
