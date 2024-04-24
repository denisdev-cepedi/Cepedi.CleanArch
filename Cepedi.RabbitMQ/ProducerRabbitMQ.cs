
using System.Text;
using System.Text.Json;
using Cepedi.RabbitMQ.Interfaces;
using RabbitMQ.Client;

namespace Cepedi.RabbitMQ;
public class ProducerRabbitMQ : IMessageProducer
{
    public void SendMessage<T>(T message)
    {
        var factory = new ConnectionFactory() { 
            HostName = "srv508250.hstgr.cloud",
            Port = 5672,
            UserName = "aluno",
            Password = "cepedialuno"
        };

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "FilaRabbitMQ",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string messageSerialized = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(messageSerialized);

            channel.BasicPublish(exchange: "",
                                 routingKey: "FilaRabbitMQ",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($" [x] Sent {messageSerialized}");
        }
    }

}
