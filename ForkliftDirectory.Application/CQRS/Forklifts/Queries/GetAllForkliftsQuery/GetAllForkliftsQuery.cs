using ForkliftDirectory.Application.DTOs.ForkliftDTOs;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.Forklifts.Queries.GetAllForkliftsQuery
{
    public class GetAllForkliftsQuery : IRequest<List<ForkliftDto>>
    {
    }
}
