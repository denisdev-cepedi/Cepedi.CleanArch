using RabbitMQ.Client;
using System.Text;


var factory = new ConnectionFactory() { HostName = "srv508250.hstgr.cloud", UserName = "aluno", Password = "changeme", Port = 5672 };

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "Testando produtor RabbitMQ JoaoP",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
    string message = "Hello World";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "Alo mundo",
                        routingKey: "hello",
                        basicProperties: null,
                        body: body);
    Console.WriteLine($" [x] Sent {0}", message);
}
Console.WriteLine($"Press [enter] to exit.");
Console.ReadLine();

