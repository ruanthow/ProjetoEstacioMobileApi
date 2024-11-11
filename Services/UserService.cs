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
            var users = await _userRepository.GetUsers(); 
            if (users == null || users.Count < 1)
            {
                return null;
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
            var user = await _userRepository.GetUserById(id); 
          
            if (user == null)
            {
                return null; 
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
                throw new ArgumentNullException(nameof(userDto)); 
            }
            
            await _userRepository.SaveUser(userDto);
        }
        
        public async Task<LoginResponseDTO> Login(LoginDTO loginDto)
        {
            if (loginDto == null)
            {
                throw new ArgumentNullException(nameof(LoginDTO)); 
            }
            
            return await _userRepository.Authentication(loginDto);
        }
    }
}