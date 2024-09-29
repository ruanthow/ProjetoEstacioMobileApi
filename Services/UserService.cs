using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoEstacio.DTOs;
using ProjetoEstacio.Model;
using ProjetoEstacio.Repository;

namespace ProjetoEstacio.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDTOResponse>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsers(); // Utilize a versão assíncrona
            if (users == null || users.Count < 1)
            {
                return null; // Retorna nulo se não houver usuários
            }

            return users.Select(user => new UserDTOResponse
            {   
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Cpf = user.Cpf
            }).ToList();
        }

        public async Task<UserDTOResponse> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUserById(id); // Utilize a versão assíncrona
          
            if (user == null)
            {
                return null; // Retorna nulo se o usuário não for encontrado
            }

            return new UserDTOResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Cpf = user.Cpf
            };
        }

        public async Task SaveUser(UserDTO userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto)); // Verifica se userDto não é nulo
            }
            
            await _userRepository.SaveUser(userDto);
        }
    }
}