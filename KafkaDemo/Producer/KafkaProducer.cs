using Confluent.Kafka;

namespace KafkaClient.Producer
{
    public class KafkaProducer
    {
        public IProducer<string, string> Producer { get; private set; }
        public ProducerConfig producerConfig { get; set; }
        public KafkaProducer()
        {
            producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                Acks = Acks.All,
                MessageSendMaxRetries = 3,
            };
            Producer = new ProducerBuilder<string, string>(producerConfig).Build();
        }
    }
}
