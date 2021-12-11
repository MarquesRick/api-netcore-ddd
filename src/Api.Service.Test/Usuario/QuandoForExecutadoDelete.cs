using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoDelete : UsuariosTestes
    {
        private IUserService _userService;
        private Mock<IUserService> _userServiceMock;

        [Fact(DisplayName = "É Possivel Executar o Método Delete.")]

        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _userService = _userServiceMock.Object;

            var deletado = await  _userService.Delete(IdUsuario);
            Assert.True(deletado);

             _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _userService = _userServiceMock.Object;

            deletado = await _userService.Delete(Guid.NewGuid());
            Assert.False(deletado);

        }
    }
}