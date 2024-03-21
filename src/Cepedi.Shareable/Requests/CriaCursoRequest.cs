using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.Shareable.Requests;
 public record CriaCursoRequest(string Nome, string Descricao, DateTime DataInicio, DateTime DataFim, int ProfessorId);