using RandevuYonetimSistemi.Models;

namespace RandevuYonetimSistemi.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
