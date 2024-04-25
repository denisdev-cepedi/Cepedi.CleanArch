using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.Banco.Pessoa.Dominio.Servicos
{
    public interface IRabbitMQProdutor
    {
        void SendMenssagem(string mensagem);
    }
}