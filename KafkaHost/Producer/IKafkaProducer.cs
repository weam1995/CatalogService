using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaClient.Producer
{
    public interface IKafkaProducer
    {
        Task ProduceAsync(string topic, Message<string, string> message);
    }
}
