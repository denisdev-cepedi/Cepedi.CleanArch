using System;
using System.Collections.Generic;

namespace Cepedi.Shareable.Requests
{
    public class CriarCursoRequest
    {
        public int IdCurso { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public ProfessorRequest Professor { get; set; }
    }

    public class ProfessorRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public List<string> Cursos { get; set; }
    }
}
