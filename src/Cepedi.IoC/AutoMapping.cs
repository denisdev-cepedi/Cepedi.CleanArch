using AutoMapper;
using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;

namespace Cepedi.IoC;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<CriarCursoRequest, CursoEntity>();
        CreateMap<AtualizarCursoRequest, CursoEntity>();
    }
}
