using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGet : UsuariosTestes
    {
        private IUserService _userService;
        private Mock<IUserService> _userServiceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GET.")]

        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _userServiceMock = new Mock<IUserService>();
            //setup mock
            _userServiceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(UserDto);
            _userService = _userServiceMock.Object;
            //now can use _userService

            var result = await _userService.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id.Equals(IdUsuario));
            //(expected value,  obtained value)
            Assert.Equal(NomeUsuario, result.Name);

            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(Task.FromResult((UserDto) null));
            _userService = _userServiceMock.Object;

            var _record = await _userService.Get(IdUsuario);
            Assert.Null(_record);
        } 

    }
}