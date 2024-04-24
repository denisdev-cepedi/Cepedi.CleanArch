using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

class Program
{
     void sendMessage()
        {

            var factory = new ConnectionFactory() { HostName = "srv508250.hstgr.cloud", UserName = "aluno", Password = "changeme", Port = 5672 };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Fila.Teste.Welvis",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "Hello World Welvis!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "Fila.Teste.Welvis",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
}
