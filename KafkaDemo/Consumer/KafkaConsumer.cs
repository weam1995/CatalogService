using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaClient.Consumer
{
    public class KafkaConsumer
    {
        //protected override Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    return Task.Run(() =>
        //    {
        //       ConsumeAsync("productChange-topic", stoppingToken);
        //    }, stoppingToken);
        //}
        public IConsumer<string, string> Consumer { get; private set; }
        public KafkaConsumer(string topic) {
            var config = new ConsumerConfig
            {
                GroupId = "cart-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = true,
                EnableAutoOffsetStore = false
            };
            Consumer = new ConsumerBuilder<string, string>(config).Build();
            Consumer.Subscribe(topic);
        }
    }
}
