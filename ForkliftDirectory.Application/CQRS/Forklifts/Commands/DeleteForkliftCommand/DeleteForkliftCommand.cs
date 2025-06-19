using MediatR;


namespace ForkliftDirectory.Application.CQRS.Forklifts.Commands.DeleteForkliftCommand
{
    public class DeleteForkliftCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteForkliftCommand(int id)
        {
            Id = id;
        }
    }
}
