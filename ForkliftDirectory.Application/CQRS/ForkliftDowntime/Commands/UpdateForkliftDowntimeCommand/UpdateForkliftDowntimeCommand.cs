using ForkliftDirectory.Application.DTOs.ForkliftDowntimeDTOs;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.ForkliftDowntime.Commands.UpdateForkliftDowntimeCommand
{
    public class UpdateForkliftDowntimeCommand : IRequest<bool>
    {
        public int Id { get; }
        public UpdateForkliftDowntimeDto Dto { get; }

        public UpdateForkliftDowntimeCommand(int id, UpdateForkliftDowntimeDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }
}
