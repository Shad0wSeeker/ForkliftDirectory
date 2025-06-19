using MediatR;


namespace ForkliftDirectory.Application.CQRS.ForkliftDowntime.Commands.DeleteForkliftDowntimeCommand
{
    public class DeleteForkliftDowntimeCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteForkliftDowntimeCommand(int id)
        {
            Id = id;
        }
    }
}
