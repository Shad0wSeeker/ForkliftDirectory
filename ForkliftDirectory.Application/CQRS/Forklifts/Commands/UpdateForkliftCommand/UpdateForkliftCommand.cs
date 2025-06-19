using ForkliftDirectory.Application.DTOs.ForkliftDTOs;
using MediatR;


namespace ForkliftDirectory.Application.CQRS.Forklifts.Commands.UpdateForkliftCommand
{
    public class UpdateForkliftCommand : IRequest<bool>
    {
        public int Id { get; }
        public UpdateForkliftDto Dto { get; }

        public UpdateForkliftCommand(int id, UpdateForkliftDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }
}
