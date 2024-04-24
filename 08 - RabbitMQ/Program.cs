using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Text;

public class Program{
    public static void Main(string[] args){
        static void ConsumidorRabbitMQ(){

        var factory = new ConnectionFactory(){ HostName = "localhost" };

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Testando",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) => 
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"[x] Received {0}", message);  
                };
                channel.BasicConsumer(queue: "hello",
                                        autoAck: true,
                                        consumer: consumer);
                Console.WriteLine($"Press [enter] to exit.");
                
            }
        }
        static void ProdutorRabbitMQ(){

            var factory = new ConnectionFactory(){ HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "Testando",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);
                    string message = "Hello World";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                        routingKey: "hello",
                                        basicProperties: null,
                                        body: body);
                    Console.WriteLine($" [x] Sent {0}", message); 
                }
                Console.WriteLine($"Press [enter] to exit.");
                Console.ReadLine();
                
        }
    }
}