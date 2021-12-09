using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoUpdate : UsuariosTestes
    {
        private IUserService _userService;
        private Mock<IUserService> _userServiceMock;

        [Fact(DisplayName = "É Possivel Executar o Método Update.")]

        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Post(UserDtoCreate)).ReturnsAsync(UserDtoCreateResult);
            _userService = _userServiceMock.Object;

            var result = await _userService.Post(UserDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);

            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Put(UserDtoUpdate)).ReturnsAsync(UserDtoUpdateResult);
            _userService = _userServiceMock.Object;

            var resultUpdate = await _userService.Put(UserDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeUsuarioAlterado, resultUpdate.Name);
            Assert.Equal(EmailUsuarioAlterado, resultUpdate.Email);
        }
    }
}