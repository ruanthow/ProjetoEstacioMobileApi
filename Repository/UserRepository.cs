using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using ProjetoEstacio.DbApllication;
using ProjetoEstacio.DTOs;
using ProjetoEstacio.Model;

namespace ProjetoEstacio.Repository
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.FromSqlRaw("SELECT * FROM users").ToListAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task SaveUser(UserDTO user)
        {
            var saveUser = new User(user.Name, user.Email, user.Password, user.Phone, user.Cpf);

            try
            {
                var exist = await _context.Users.FirstOrDefaultAsync(u => u.Email == saveUser.Email);
                if (exist != null)
                { 
                    throw new CustomException("Email já cadastrado", "400");
                }

                await _context.Users.AddAsync(saveUser);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                // Captura erros relacionados a atualizações no banco de dados
                throw new Exception($"Ago deu errado");
            }
            
        }


        public async Task EditUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Usuário não encontrado.");
            }
        }
    }
}
