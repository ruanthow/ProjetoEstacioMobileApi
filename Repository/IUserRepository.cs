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
        Task<User> GetUserById(String userId);
        void SaveUser(UserDTOResponse user);
        void EditUser(User user);
        void DeleteUser(Guid id);
    }
}