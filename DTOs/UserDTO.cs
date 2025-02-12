using RandevuYonetimSistemi.Models;

namespace RandevuYonetimSistemi.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
