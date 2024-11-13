using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaClient.Producer
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly IProducer<string, string> _producer;
        public KafkaProducer() {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
            };
            _producer = new ProducerBuilder<string, string>(config).Build();
        }  
        public async Task ProduceAsync (string  topic, Message<string, string> message)
        {
            try
            {
                var dr = await _producer.ProduceAsync(topic, message);
            }
            catch (ProduceException<string,string> e) {
                throw new Exception("Error occured while producing message");
           }
        }
    }
}
