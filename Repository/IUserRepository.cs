using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoEstacio.DTOs;
using ProjetoEstacio.Model;

namespace ProjetoEstacio.Repository
{
    public interface IUserRepository
    {
       Task<List<User>> GetUsers();
        Task<User> GetUserById(Guid userId);
        Task SaveUser(UserDTO user);
        Task EditUser(User user);
        Task DeleteUser(Guid id);
    }
}