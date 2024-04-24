using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "srv508250.hstgr.cloud",
            UserName = "aluno",
            Password = "changeme"
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        {
            channel.QueueDeclare(queue: "Alan Prates",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            string message = "Teste de envio de mensagem! Alan Prates";
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "",
                routingKey: "pratestarrk",
                basicProperties: null,
                body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
        

    }
}