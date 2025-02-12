namespace RandevuYonetimSistemi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public ICollection<Appointment> Appointments { get; set; }
    }

    public enum UserRole
    {
        Admin,
        User
    }
}
