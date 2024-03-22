using Cepedi.Domain;
using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data;

public class CursoRepository : ICursoRepository
{
    private readonly ApplicationDbContext _context;

    public CursoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso) => 
    await _context.Curso.Where(curso => curso.Id == idCurso).FirstOrDefaultAsync();

    public async Task<CursoEntity> CriaCursoAsync(CursoEntity curso)
    {
        await _context.Curso.AddAsync(curso);
        await _context.SaveChangesAsync();
        return curso;
    }

    public async Task<CursoEntity> AtualizarCursoAsync(CursoEntity curso, CriaCursoRequest cursoRequest, ProfessorEntity professor)
    {
        if(cursoRequest.nome is not null) curso.Nome = cursoRequest.nome;
        if(cursoRequest.descricao is not null) curso.Descricao = cursoRequest.descricao;
        curso.DataInicio = cursoRequest.inicio;
        curso.DataFim = cursoRequest.fim;
        if(professor is not null)
        {
            curso.Professor = professor;
            curso.ProfessorId = professor.Id;
        }

        _context.Curso.Update(curso);
        await _context.SaveChangesAsync();

        return curso;
    }

    public async Task ExcluirCursoAsync(CursoEntity curso)
    {
        curso.Descricao += " - Curso removido";
        _context.Curso.Update(curso);
        await _context.SaveChangesAsync();
    }
}
