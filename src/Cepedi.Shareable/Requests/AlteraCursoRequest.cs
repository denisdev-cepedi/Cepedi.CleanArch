using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.Shareable.Requests;
public record AlteraCursoRequest(int idCurso, string Nome, string Descricao, DateTime DataInicio, DateTime DataFim, int ProfessorId);
