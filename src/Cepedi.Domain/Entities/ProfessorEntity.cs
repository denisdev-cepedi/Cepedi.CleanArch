using System;
using System.Collections.Generic;

namespace Cepedi.Domain.Entities
{
    public class ProfessorEntity
    {
        public ProfessorEntity(int id, string nome, string especialidade)
        {
            Id = id;
            Nome = nome;
            Especialidade = especialidade;
        }

        public ProfessorEntity()
        {
            // Implementação do construtor padrão aqui, se necessário
            // Por exemplo, você pode inicializar propriedades com valores padrão
            Id = 0;
            Nome = "Novo Professor";
            Especialidade = "Nenhuma Especialidade";
        }

        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public string Especialidade { get; set; } = default!;
        public List<CursoEntity> Cursos { get; set; } = new();
    }
}
