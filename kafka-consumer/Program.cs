using System;
using Confluent.Kafka;

class Program
{
    static void Main(string[] args)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "159.223.189.57:9092",
            GroupId = "test-topic",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false
        };

        using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
        {
            consumer.Subscribe("test-topic");

            while (true)
            {
                var message = consumer.Consume();

                Console.WriteLine($"Received message: {message.Message.Value} at offset {message.Offset}");

                // Commit the message so that it is not read again.
                consumer.Commit(message);
            }
        }
    }
}

