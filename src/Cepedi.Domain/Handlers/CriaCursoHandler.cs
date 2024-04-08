using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers
{
    public class CriaCursoHandler : IRequestHandler<CriaCursoRequest, CriaCursoResponse>
    {
        private readonly ICursoRepository _cursoRepository;
        //  private readonly IWhatsApp _whatsApp;

        public CriaCursoHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
            // _whatsApp = whatsApp;
        }

        public async Task<int> CriarCursoAsync(CriaCursoRequest request)
        {
            var novoCurso = new CursoEntity
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                DataInicio = request.DataInicio,
                DataFim = request.DataFim,
                ProfessorId = request.ProfessorId,
                // Telefone = request.telefone
            };


            // var retornoMensagem = await _whatsApp.EnviarMensagemWhatsAppAsync(request.telefone, $"O curso {request.Descricao} está aberto");

            // if(retornoMensagem == "Sucesso"){
            //     Console.WriteLine("Enviado com sucesso!");
            // }else{
            //     throw new Exception("Erro");
            // }

            return await _cursoRepository.CriaNovoCursoAsync(novoCurso);

        }

        public async Task<CriaCursoResponse> Handle(CriaCursoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var novoCurso = new CursoEntity()
                {
                    Nome = request.Nome,
                    Descricao = request.Descricao,
                    DataInicio = request.DataInicio,
                    DataFim = request.DataFim,
                    ProfessorId = request.ProfessorId,
                    // Telefone = request.telefone
                };
                await _cursoRepository.CriaNovoCursoAsync(novoCurso);
                return new CriaCursoResponse(novoCurso.Nome, novoCurso.Descricao, novoCurso.ProfessorId);

            }
            catch
            {
                throw;
            }
        }
    }
}
