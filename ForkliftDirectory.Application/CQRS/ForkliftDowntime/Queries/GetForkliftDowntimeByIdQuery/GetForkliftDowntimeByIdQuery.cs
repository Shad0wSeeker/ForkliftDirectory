using ForkliftDirectory.Application.DTOs.ForkliftDowntimeDTOs;
using MediatR;

namespace ForkliftDirectory.Application.CQRS.ForkliftDowntime.Queries.GetForkliftDowntimeByIdQuery
{
    public class GetForkliftDowntimeByIdQuery : IRequest<ForkliftDowntimeDto>
    {
        public int Id { get; }

        public GetForkliftDowntimeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
