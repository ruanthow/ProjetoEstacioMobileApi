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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                var users = await _context.Users.FromSqlRaw("SELECT * FROM users").ToListAsync();
                if (users != null)
                {
                    return users;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Operação deu errado. tente mais tarde.");
            }
            
        }

        public async Task<User> GetUserById(Guid id)
        {
            try
            {
                var findUser = await _context.Users.FindAsync(id);

                if (findUser != null)
                {
                    return findUser;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Operação deu errado. tente mais tarde.");
            }
        }

        public async Task SaveUser(UserDTO user)
        {
            var saveUser = new User(user.Name, user.Email, user.Password, user.Phone, user.Cpf);

            try
            {
                var findUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == saveUser.Email);
                if (findUser != null)
                { 
                    throw new CustomException("Email já cadastrado", "400");
                }

                await _context.Users.AddAsync(saveUser);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {   
                Console.WriteLine(dbEx);
                throw new Exception("Operação deu errado. tente mais tarde.");
            }
            
        }


        public async Task EditUser(User user)
        {
            try
            {
                var findUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
                if (findUser != null)
                {
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    return;
                }
                throw new Exception("Usuario não encontrado."); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Operação deu errado. tente mais tarde.");
            }
        }

        public async Task DeleteUser(Guid id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return;
                }
                throw new Exception("Usuário não encontrado.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Operação deu errado. tente mais tarde.");
            }
        }
        
    }
}
