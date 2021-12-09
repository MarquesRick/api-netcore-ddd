using System;
using System.Collections.Generic;
using Api.Domain.Dtos.User;

namespace Api.Service.Test.Usuario
{
    public class UsuariosTestes
    {
        public static string NomeUsuario { get; set; }
        
        public static string EmailUsuario { get; set; }

         public static string NomeUsuarioAlterado { get; set; }
        
        public static string EmailUsuarioAlterado { get; set; }

        public static Guid IdUsuario {get; set;}

        public List<UserDto> ListaUserDto = new List<UserDto>();

        public UserDto UserDto;

        public UserDtoCreate UserDtoCreate;

        public UserDtoCreateResult UserDtoCreateResult;

        public UserDtoUpdate UserDtoUpdate;

        public UserDtoUpdateResult UserDtoUpdateResult;

        public UsuariosTestes()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Faker.Name.FullName();
            EmailUsuario = Faker.Internet.Email();
            NomeUsuarioAlterado = Faker.Name.FullName();
            EmailUsuarioAlterado = Faker.Internet.Email();

            //create a fake list of ListaUserDto()
            for(var i = 0; i < 10; i++)
            {
                var dto = new UserDto(){
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };

                ListaUserDto.Add(dto);
            }

            UserDto = new UserDto{
                Id = IdUsuario,
                Email = EmailUsuario,
                Name = NomeUsuario
            };

            UserDtoCreate = new UserDtoCreate{
                Name = NomeUsuario,
                Email = EmailUsuario
            };

            UserDtoCreateResult = new UserDtoCreateResult{
                Id = IdUsuario,
                CreateAt = DateTime.UtcNow,
                Name = NomeUsuario,
                Email = EmailUsuario
            };

            UserDtoUpdate = new UserDtoUpdate{
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado
            };

            UserDtoUpdateResult = new UserDtoUpdateResult{
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}