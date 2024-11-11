namespace ProjetoEstacio.DTOs
{
    public record LoginResponseDTO(string token, string idUser, string email, string name);
}