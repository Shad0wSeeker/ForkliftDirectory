using ForkliftDirectory.Application.DTOs.ForkliftDTOs;
using MediatR;

namespace ForkliftDirectory.Application.CQRS.Forklifts.Commands.CreateForkliftCommand
{
    public class CreateForkliftCommand : IRequest<int>
    {
        public CreateForkliftDto Dto { get;  } 

        public CreateForkliftCommand(CreateForkliftDto dto)
        {
            Dto = dto;
        }
    }
}
