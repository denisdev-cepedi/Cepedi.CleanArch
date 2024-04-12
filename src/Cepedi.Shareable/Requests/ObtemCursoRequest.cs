﻿using Cepedi.Shareable.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Shareable.Requests;
public class ObtemCursoRequest : IRequest<Result<ObtemCursoResponse>>
{
    public int IdCurso { get; set; }
}
