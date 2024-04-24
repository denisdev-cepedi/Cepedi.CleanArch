using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.Banco.Pessoa.Compartilhado.Responses
{
    public class ObterCepResponse
    {
        public string Cep { get; set; } = default!;
        public string Logradouro { get; set; }= default!;
        public string complemento { get; set; }= default!;
        public string bairro { get; set; }= default!;
        public string localidade { get; set; }= default!;
        public string uf { get; set; }= default!;
        public string ibge { get; set; }= default!;
        public string gia { get; set; }= default!;
        public string ddd { get; set; }= default!;
        public string siafi { get; set; }= default!;
    }
}