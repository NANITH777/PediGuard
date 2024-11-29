using Microsoft.EntityFrameworkCore;
using PediGuard.Models;

namespace PediGuard.Utility
{
    public class AppointmentService
    {
        private readonly ApplicationDbContext _context;

        public AppointmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsNobetAvailable(int nobetId)
        {
            // Check if the Nobet shift is already booked
            var existingAppointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.NobetID == nobetId &&
                                          a.Status != AppointmentStatus.Cancelled);

            return existingAppointment == null;
        }

        public async Task<Appointment> BookAppointment(int nobetId, string applicationUserId)
        {
            // Retrieve the Nobet shift
            var nobet = await _context.Nobets
                .Include(n => n.Assistant)
                .Include(n => n.Department)
                .FirstOrDefaultAsync(n => n.ID == nobetId);

            if (nobet == null)
            {
                throw new ArgumentException("Nobet shift not found");
            }

            // Check if the shift is available
            if (!await IsNobetAvailable(nobetId))
            {
                throw new InvalidOperationException("This shift is already booked");
            }

            // Create new appointment
            var appointment = new Appointment
            {
                NobetID = nobet.ID,
                ApplicationUserId = applicationUserId,
                Status = AppointmentStatus.Pending,
                Notes = $"Appointment with {nobet.Assistant.FullName} in {nobet.Department.Name}"
            };

            // Save the appointment
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return appointment;
        }

        public async Task<List<Nobet>> GetAvailableNobetShifts(DateTime? specificDate = null)
        {
            // Query for Nobet shifts that are not yet booked
            var query = _context.Nobets
                .Include(n => n.Assistant)
                .Include(n => n.Department)
                .Where(n => !_context.Appointments
                    .Any(a => a.NobetID == n.ID &&
                              a.Status != AppointmentStatus.Cancelled));

            // Optional: Filter by specific date
            if (specificDate.HasValue)
            {
                query = query.Where(n => n.Date.Date == specificDate.Value.Date);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> CancelAppointment(int appointmentId)
        {
            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.ID == appointmentId);

            if (appointment == null)
            {
                return false;
            }

            appointment.Status = AppointmentStatus.Cancelled;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ReleaseNobetSlot(int nobetId)
        {
            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.NobetID == nobetId &&
                                          a.Status != AppointmentStatus.Cancelled);

            if (appointment == null)
            {
                return false;
            }

            // Release the slot by cancelling the appointment
            appointment.Status = AppointmentStatus.Cancelled;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}