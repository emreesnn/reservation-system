using Microsoft.EntityFrameworkCore;
using RandevuYonetimSistemi.Data.Context;
using RandevuYonetimSistemi.Models;
using RandevuYonetimSistemi.DTOs;

namespace RandevuYonetimSistemi.Services
{
    public class AppointmentService
    {
        private readonly AppDbContext _context;

        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AppointmentDTO>> GetAllAppointments()
        {
            var appointments = await _context.Appointments.ToListAsync();
            return appointments.Select(a => new AppointmentDTO
            {
                Id = a.Id,
                UserId = a.UserId,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status
            }).ToList();
        }

        public async Task<AppointmentDTO> GetAppointmentById(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return null;

            return new AppointmentDTO
            {
                Id = appointment.Id,
                UserId = appointment.UserId,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status
            };
        }

        public async Task<AppointmentDTO> CreateAppointment(AppointmentDTO appointmentDto)
        {
            var appointment = new Appointment
            {
                UserId = appointmentDto.UserId,
                AppointmentDate = appointmentDto.AppointmentDate,
                Status = appointmentDto.Status
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();


            return new AppointmentDTO
            {
                Id = appointment.Id,
                UserId = appointment.UserId,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status
            };
        }

        public async Task<bool> UpdateAppointment(int id, AppointmentDTO appointmentDto)
        {
            var existingAppointment = await _context.Appointments.FindAsync(id);
            if (existingAppointment == null)
                return false;

            existingAppointment.AppointmentDate = appointmentDto.AppointmentDate;
            existingAppointment.Status = appointmentDto.Status;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                return false;

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
