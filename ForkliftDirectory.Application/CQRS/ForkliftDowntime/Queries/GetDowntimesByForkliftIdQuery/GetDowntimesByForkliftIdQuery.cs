using ForkliftDirectory.Application.DTOs.ForkliftDowntimeDTOs;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.ForkliftDowntime.Queries.GetDowntimesByForkliftIdQuery
{
    public class GetDowntimesByForkliftIdQuery : IRequest<List<ForkliftDowntimeDto>>
    {
        public int ForkliftId { get; }

        public GetDowntimesByForkliftIdQuery(int forkliftId)
        {
            ForkliftId = forkliftId;
        }
    }
}
