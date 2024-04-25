using RabbitMQ.Client; // Importa o namespace necessário para interagir com o RabbitMQ
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        SendMessage(); // Chama o método para enviar uma mensagem
    }

    static void SendMessage()
    {
        try
        {
            // Configuração da fábrica de conexão com o RabbitMQ
            var factory = new ConnectionFactory()
            {
                HostName = "srv508250.hstgr.cloud", // Hostname do servidor RabbitMQ
                UserName = "aluno", // Nome de usuário para autenticação
                Password = "changeme", // Senha para autenticação
                Port = 5672 // Porta padrão do RabbitMQ
            };

            // Criação e utilização da conexão e do canal (channel) RabbitMQ
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Declaração da fila no RabbitMQ
                channel.QueueDeclare(queue: "FilaRabbitMQ.Kayque",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "Hasta la vista, baby";
                var body = Encoding.UTF8.GetBytes(message);

                // Publica a mensagem na fila especificada
                channel.BasicPublish(exchange: "",
                                     routingKey: "FilaRabbitMQ.Kayque",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine(" [x] Sent {0}", message);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine(); // Aguarda a entrada do usuário antes de sair
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}"); // Exibe mensagem de erro em caso de exceção
        }
    }
}
