using ForkliftDirectory.Application.DTOs.ForkliftDowntimeDTOs;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.ForkliftDowntime.Commands.CreateForkliftDowntimeCommand
{
    public class CreateForkliftDowntimeCommand : IRequest<int>
    {
        public CreateForkliftDowntimeDto Dto { get; }
        public CreateForkliftDowntimeCommand(CreateForkliftDowntimeDto dto)
        {
            Dto = dto;
        }
    }
}
