namespace ProjetoEstacio.Model
{
    public class Crypto
    {
        public static string RegisterUser(string password)
        {

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

        public static bool LoginUser(string password, string storedHashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHashedPassword);
        }
    }
}