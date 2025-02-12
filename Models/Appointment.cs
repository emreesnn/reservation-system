namespace RandevuYonetimSistemi.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime AppointmentDate { get; set; }

        public AppointmentStatus Status { get; set; } = AppointmentStatus.Active;
    }
    public enum AppointmentStatus
    {
        Active,
        Cancelled
    }
}
