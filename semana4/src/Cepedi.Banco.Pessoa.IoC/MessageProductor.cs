using System.Text;
using Cepedi.Banco.Pessoa.Dominio.Services;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
namespace Cepedi.Banco.Pessoa.Dominio.IoC
{
    public class MessageProductor : IMessageProductor
    {
        protected IConfiguration Configuration { get; }

        public MessageProductor(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //         Port = 5672
        // "Hostname": "srv508250.hstgr.cloud",
        // "QueueName": "FilaRabbitMQ",



        // "RabbitMQ": {
        //   "Hostname": "srv508250.hstgr.cloud",
        //   "QueueName": "Fila.Teste",
        //   "User": "aluno",
        //   "Password": "changeme"
        // }

        public void SendingMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = Configuration["RabbitMQ:Hostname"], Port = 5672, UserName = Configuration["RabbitMQ:User"], Password = Configuration["RabbitMQ:Password"] };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: Configuration["RabbitMQ:QueueName"],
                durable: false,exclusive: false,autoDelete: false,arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: Configuration["RabbitMQ:QueueName"], basicProperties: null, body: body);

                Console.WriteLine(" [x] Sent {0}", message);
            }

        }
    }
}
