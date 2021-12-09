using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGetAll : UsuariosTestes
    {
        private IUserService _userService;
        private Mock<IUserService> _userServiceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GETAll.")]

        public async Task E_Possivel_Executar_Metodo_GetAll()
        {
            _userServiceMock = new Mock<IUserService>();
            //setup mock
            _userServiceMock.Setup(m => m.GetAll()).ReturnsAsync(ListaUserDto);
            _userService = _userServiceMock.Object;
            //now can use _userService

            var result = await _userService.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<UserDto>();
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _userService = _userServiceMock.Object;

            var _resultEmpty = await _userService.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }

    }
}