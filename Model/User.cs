using System;

namespace ProjetoEstacio.Model
{
    public class User
    {
        private Guid Id { get; set; }
        private string Name { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }
        private string Phone { get; set; }
        private string Cpf { get; set; }
        
        public User(string name, string email, string password, string phone, string cpf)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
            this.Cpf = cpf;
        }
    }
}