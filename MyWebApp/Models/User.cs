namespace MyWebApp.Models
{
    public class User
    {
        public int Id { get; set; } // Primary Key
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // Store hashed passwords in real apps
    }
}
