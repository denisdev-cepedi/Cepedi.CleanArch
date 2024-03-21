using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Data;
using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cepedi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ILogger<CursoController> _logger;
        private readonly ApplicationDbContext _context;

        public CursoController(ILogger<CursoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{idCurso}")]
        public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
        {
            try
            {
                // Busca o curso no banco de dados com base no ID fornecido
                var curso = await _context.Curso
                    .Include(c => c.Professor) // Inclui o professor relacionado ao curso
                    .FirstOrDefaultAsync(c => c.Id == idCurso);

                if (curso == null)
                {
                    // Se o curso não for encontrado, retorna um resultado NotFound
                    return NotFound($"Curso com ID {idCurso} não encontrado.");
                }

                // Monta a resposta com os detalhes do curso
                var response = new ObtemCursoResponse(curso.Nome, $"De {curso.DataInicio.ToShortDateString()} até {curso.DataFim.ToShortDateString()}", curso.Professor.Nome);

                // Retorna um resultado Ok com os detalhes do curso
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Em caso de erro, registra um log de erro e retorna uma resposta de status 500 (Internal Server Error)
                _logger.LogError(ex, "Erro ao consultar o curso.");
                return StatusCode(500, "Ocorreu um erro ao consultar o curso.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CursoEntity>> CriarCursoAsync([FromBody] CriarCursoRequest request)
        {
            try
            {
                var novoCurso = new CursoEntity
                {
                    Id = request.IdCurso,
                    Nome = request.Nome,
                    Descricao = request.Descricao,
                    DataInicio = request.DataInicio,
                    DataFim = request.DataFim,
                    Professor = new ProfessorEntity
                    {
                        Id = request.Professor.Id,
                        Nome = request.Professor.Nome,
                        Especialidade = request.Professor.Especialidade,
                        Cursos = new List<CursoEntity>()
                    }
                };

                _context.Curso.Add(novoCurso);
                await _context.SaveChangesAsync();

                // Serializa o novo curso para JSON com as opções de preservação de referência
                var json = JsonSerializer.Serialize(novoCurso, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve });

                // Retorna um resultado Ok com o novo curso criado
                return Ok(json);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar o curso.");
                return StatusCode(500, "Ocorreu um erro ao criar o curso.");
            }
        }
        [HttpPut("{idCurso}")]
        public async Task<ActionResult<CursoEntity>> AtualizarCursoAsync([FromRoute] int idCurso, [FromBody] AtualizarCursoRequest request)
        {
            try
            {
                // Consulta o curso pelo ID no banco de dados, incluindo o ProfessorEntity
                var curso = await _context.Curso.Include(c => c.Professor).FirstOrDefaultAsync(c => c.Id == idCurso);

                if (curso == null)
                {
                    // Se o curso não for encontrado, retorna um resultado NotFound
                    return NotFound($"Curso com ID {idCurso} não encontrado.");
                }

                // Atualiza as propriedades do curso com base nos dados da solicitação
                curso.Nome = request.Nome;
                curso.Descricao = request.Descricao;
                curso.DataInicio = request.DataInicio;
                curso.DataFim = request.DataFim;

                // Verifica se o ProfessorEntity associado precisa ser atualizado
                if (curso.Professor != null)
                {
                    curso.Professor.Nome = request.ProfessorNome;
                    curso.Professor.Especialidade = request.ProfessorEspecialidade;
                }
                else
                {
                    // Se não houver um ProfessorEntity associado, cria um novo
                    curso.Professor = new ProfessorEntity
                    {
                        Nome = request.ProfessorNome,
                        Especialidade = request.ProfessorEspecialidade
                    };
                }

                // Salva as alterações no banco de dados
                await _context.SaveChangesAsync();

                // Retorna um resultado Ok com o curso atualizado
                return Ok(curso);
            }
            catch (Exception ex)
            {
                // Em caso de erro, registra um log de erro e retorna uma resposta de status 500 (Internal Server Error)
                _logger.LogError(ex, "Erro ao atualizar o curso.");
                return StatusCode(500, "Ocorreu um erro ao atualizar o curso.");
            }
        }

        [HttpDelete("{idCurso}")]
        public async Task<IActionResult> ExcluirCursoAsync([FromRoute] int idCurso)
        {
            try
            {
                // Verifica se o curso com o ID especificado existe no banco de dados, incluindo o ProfessorEntity
                var curso = await _context.Curso.Include(c => c.Professor).FirstOrDefaultAsync(c => c.Id == idCurso);
                if (curso == null)
                {
                    // Se o curso não for encontrado, retorna um código de status 404 (Not Found)
                    return NotFound($"Curso com ID {idCurso} não encontrado.");
                }

                // Remove o curso do contexto do banco de dados
                _context.Curso.Remove(curso);

                // Verifica se há um professor associado ao curso e remove-o também
                if (curso.Professor != null)
                {
                    _context.Professor.Remove(curso.Professor);
                }

                // Salva as mudanças no banco de dados
                await _context.SaveChangesAsync();

                // Retorna um código de status 204 (No Content) indicando que o curso foi excluído com sucesso
                return NoContent();
            }
            catch (Exception ex)
            {
                // Em caso de erro, registra um log de erro e retorna uma resposta de status 500 (Internal Server Error)
                _logger.LogError(ex, "Erro ao excluir o curso.");
                return StatusCode(500, "Ocorreu um erro ao excluir o curso.");
            }
        }


    }
}
