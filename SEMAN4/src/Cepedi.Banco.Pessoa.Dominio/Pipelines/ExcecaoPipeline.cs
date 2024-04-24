using System.Reflection;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Pessoa.Dominio.Pipelines;
public sealed class ExcecaoPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<ExcecaoPipeline<TRequest, TResponse>> _logger;

    public ExcecaoPipeline(ILogger<ExcecaoPipeline<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogInformation("Request handler {dados}", request);
            }

            var response = await next.Invoke();

            return response;

        }
        catch (Exception e)
        {
            // Log the exception
            _logger.LogError(e, "An exception occurred during the request handling.");

            var erro = Result.Error<TResponse>(e);

            var retorno = AlterarPropriedadeComReflection<TResponse>(erro.Value, erro.Exception);
            return (TResponse)(object)retorno;
        }
    }

    private static object AlterarPropriedadeComReflection<T>(Result<T> result, Exception exception)
    {
        PropertyInfo valueProperty = typeof(Result<T>).GetProperty("Value", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (valueProperty != null)
        {
            var value = valueProperty.GetValue(result);

            // Obtém o tipo da classe
            Type valueType = value.GetType();

            // Obtém o campo subjacente da propriedade 'Exception'
            FieldInfo exceptionField = valueType.GetField("<Exception>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);

            if (exceptionField != null)
            {
                // Define o valor do campo 'Exception' usando reflection
                exceptionField.SetValue(value, exception);
            }


            return value;
        }

        return result;
    }

}
