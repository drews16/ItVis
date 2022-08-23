namespace ItVis.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; } = null!;
    }
}
