using Confluent.Kafka;

class Program{
    static async Task Main(string[] args){
        string msg = args[0];

        var config = new ProducerConfig
        {
            BootstrapServers = "159.223.189.57:9092"
        };

        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            var message = new Message<Null, string>
            {
                Value = msg
            };

            var deliveryReport = await producer.ProduceAsync("test-topic", message);

            Console.WriteLine($"Delivered message to {deliveryReport.TopicPartitionOffset}");
        }
    }
}
