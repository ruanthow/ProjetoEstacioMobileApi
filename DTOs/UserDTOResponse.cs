using System;

namespace ProjetoEstacio.DTOs
{
    public class UserDTOResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
    }
}