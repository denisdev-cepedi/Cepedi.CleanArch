using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cepedi.Banco.Pessoa.Compartilhado;
using Cepedi.Banco.Pessoa.Compartilhado.Excecoes;
using FluentValidation;
using MediatR;

namespace Cepedi.Banco.Pessoa.Dominio.Pipelines;
public sealed class ValidacaoComportamento<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IValida
{
    private AbstractValidator<TRequest> _validator;
    public ValidacaoComportamento(AbstractValidator<TRequest> validator) => _validator = validator;
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var resultadoValidacao = await _validator.ValidateAsync(request, cancellationToken);

        if (resultadoValidacao.IsValid)
        {
            return await next.Invoke();
        }

        var context = new ValidationContext<TRequest>(request);
        var errorsDictionary = resultadoValidacao
            .Errors
            .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .ToDictionary(x => x.Key, x => x.Values);

        if (errorsDictionary.Any())
        {
            throw new RequestInvalidaException(errorsDictionary);
        }

        return await next();
    }
}
