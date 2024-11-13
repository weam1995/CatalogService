using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaClient.Producer
{
    public class KafkaProducer
    {
       public  IProducer<string, string> Producer { get; private set; }
        public KafkaProducer() {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
            };
            Producer = new ProducerBuilder<string, string>(config).Build();
        }  
    }
}
