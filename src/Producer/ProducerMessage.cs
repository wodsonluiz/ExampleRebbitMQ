using System;
using System.Text;
using Producer.Abstractions;
using RabbitMQ.Client;

namespace Producer
{
    public class ProducerMessage : IProducerMessage
    {
        public ProducerMessage()
        {

        }

        public void Send(string message)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    Uri = new Uri("amqp://guest:guest@localhost:5672/")
                };

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "hello3",
                                             durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish(exchange: "exchangeHello",
                                             routingKey: "hello3",
                                             basicProperties: null,
                                             body: body);

                        Console.WriteLine(" [x] Sent {0}", message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
