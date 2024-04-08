using Cepedi.BancoCentral.WebApi.Controllers;
using Cepedi.Shareable.Requests;
using MediatR;
using NSubstitute;

namespace Cepedi.BancoCentral.WebApi.Tests
{
    public class UserControllerTests
    {
        private readonly IMediator _mediator = Substitute.For<IMediator>();
        private readonly UserController _sut;

        [Fact]
        public async Task CriarUsuario_DeveEnviarRequest_Para_Mediator()
        {
            // Arrange 
            var request = new CriarUsuarioRequest { Nome = "Denis" };

            // Act
            await _sut.CriarUsuarioAsync(request);

            // Assert
            await _mediator.ReceivedWithAnyArgs().Send(request);
        }
    }
}
