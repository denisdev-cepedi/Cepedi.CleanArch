using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Shareable.Requests;

public class ObterUsuariosRequest : IRequest<List<ObterUsuariosResponse>>{}
