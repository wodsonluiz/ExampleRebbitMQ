using Producer.Abstractions;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Producer
{
    public class ProducerMessage : IProducerMessage
    {
        public async Task<bool> Send(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "hello",
                                         basicProperties: null,
                                         body: body);

                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }

            return true;
           
        }
    }
}
