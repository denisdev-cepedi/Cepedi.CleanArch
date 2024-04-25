using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using System.Text;

namespace Cepedi.Banco.Pessoa.Dominio.Servicos
{
    public class RabbitMQProdutor : IRabbitMQProdutor
    {
        
        public void SendMenssagem(string mensagem){
            var factory = new ConnectionFactory() { 
                HostName = "srv508250.hstgr.cloud", 
                UserName = "aluno", 
                Password = "changeme", 
                Port = 5672 
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Hi Lorena",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
                
                var body = Encoding.UTF8.GetBytes(mensagem);
                channel.BasicPublish(exchange: "",
                                    routingKey: "Hi Lorena",
                                    basicProperties: null,
                                    body: body);
                Console.WriteLine(" [x] Sent {0}", mensagem);
            }
        }
    }
}