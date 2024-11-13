namespace CatalogService.Domain.Entities
{
    public class OutboxMessage
    {
        /// <summary>
        /// Id of message.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Occurred on.
        /// </summary>
        public DateTime OccurredOn { get; private set; }

        /// <summary>
        /// Full name of message type.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Message data - serialzed to JSON.
        /// </summary>
        public string Data { get; private set; }

        private OutboxMessage()
        {

        }

        internal OutboxMessage(DateTime occurredOn, string type, string data)
        {
            Id = Guid.NewGuid();
            OccurredOn = occurredOn;
            Type = type;
            Data = data;
        }

    }
}
