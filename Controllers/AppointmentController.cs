using Microsoft.AspNetCore.Mvc;
using RandevuYonetimSistemi.Services;
using RandevuYonetimSistemi.DTOs;

[Route("api/appointments/[action]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly AppointmentService _appointmentService;

    public AppointmentController(AppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAppointments()
    {
        var appointments = await _appointmentService.GetAllAppointments();
        return Ok(appointments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointmentById(int id)
    {
        var appointment = await _appointmentService.GetAppointmentById(id);
        if (appointment == null)
            return NotFound("Randevu bulunamadı.");

        return Ok(appointment);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAppointment([FromBody] AppointmentDTO appointmentDto)
    {
        if (appointmentDto == null)
            return BadRequest("Geçersiz veri.");

        var createdAppointment = await _appointmentService.CreateAppointment(appointmentDto);
        return CreatedAtAction(nameof(GetAppointmentById), new { id = createdAppointment.Id }, createdAppointment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAppointment(int id, [FromBody] AppointmentDTO appointmentDto)
    {
        if (appointmentDto == null)
            return BadRequest("Geçersiz veri.");

        var updated = await _appointmentService.UpdateAppointment(id, appointmentDto);
        if (!updated)
            return NotFound("Güncellenecek randevu bulunamadı.");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        var deleted = await _appointmentService.DeleteAppointment(id);
        if (!deleted)
            return NotFound("Silinecek randevu bulunamadı.");

        return NoContent();
    }
}
