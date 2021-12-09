using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoCreate : UsuariosTestes
    {
        private IUserService _userService;
        private Mock<IUserService> _userServiceMock;

        [Fact(DisplayName = "É Possivel Executar o Método Create.")]

        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Post(UserDtoCreate)).ReturnsAsync(UserDtoCreateResult);
            _userService = _userServiceMock.Object;

            var result = await _userService.Post(UserDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);
        }
    }
}