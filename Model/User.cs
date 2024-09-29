using System;

namespace ProjetoEstacio.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
        
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