namespace TraversalCoreProje.CQRS.Commands.DestinationCommands
{
    public class RemoveDestinationCommand
    {
        public int DestinationId { get; set; }

        public RemoveDestinationCommand(int destinationId)
        {
            DestinationId = destinationId;
        }
    }
}
