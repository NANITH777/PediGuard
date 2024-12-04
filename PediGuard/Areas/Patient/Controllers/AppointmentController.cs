﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PediGuard.Helper;
using PediGuard.Models;
using PediGuard.Models.ViewModels;
using PediGuard.Repository.IRepository;
using PediGuard.Utility;
using System.Security.Claims;

namespace PediGuard.Areas.Patient.Controllers
{
    [Area("Patient")]
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppointmentService _appointmentService;

        public AppointmentController(
            IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager,
            AppointmentService appointmentService)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _appointmentService = appointmentService;
        }

        // List of patient appointments
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var appointments = _unitOfWork.Appointment
                .GetAll(a => a.ApplicationUserId == userId,
                    includeProperties: "Nobet,Nobet.Assistant,Nobet.Department")
                .OrderByDescending(a => a.Nobet.Date)
                .ToList();

            return View(appointments);
        }

        // Book an appointment
        [HttpGet]
        public async Task<IActionResult> Book(int nobetId)
        {
            var nobet = _unitOfWork.Nobet.Get(
                n => n.ID == nobetId,
                includeProperties: "Assistant,Department");

            if (nobet == null)
            {
                TempData["error"] = "Slot not found.";
                return RedirectToAction("Index", "Home");
            }

            var isAvailable = await _appointmentService.IsNobetAvailable(nobetId);
            if (!isAvailable)
            {
                TempData["error"] = "This slot is already booked.";
                return RedirectToAction("Index", "Home");
            }

            var appointmentVM = new AppointmentVM
            {
                Appointment = new Appointment { NobetID = nobetId },
                NobetList = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = nobet.ID.ToString(),
                        Text = $"{nobet.Assistant.FullName} - {nobet.Department.Name} - {nobet.Date:dd/MM/yyyy}"
                    }
                }
            };

            return View(appointmentVM);
        }

        // Confirm booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(AppointmentVM appointmentVM)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            System.Diagnostics.Debug.WriteLine($"Received Time: {appointmentVM.Appointment.Time}");
            var appointment = new Appointment
            {
                NobetID = appointmentVM.Appointment.NobetID,
                ApplicationUserId = userId,
                Status = AppointmentStatus.Pending,
                Notes = appointmentVM.Appointment.Notes,
                Time = appointmentVM.Appointment.Time
            };

            try
            {
                var bookedAppointment = await _appointmentService.BookAppointment(appointment.NobetID, userId);

                if (bookedAppointment != null)
                {
                    TempData["success"] = "Appointment booked successfully!";
                    return RedirectToAction(nameof(Details), new { id = bookedAppointment.ID });
                }
                else
                {
                    TempData["error"] = "Unable to book this appointment. It may already be taken.";
                    return RedirectToAction(nameof(Book), new { nobetId = appointmentVM.Appointment.NobetID });
                }
            }
            catch (Exception ex)
            {
                // Logging the error is recommended
                TempData["error"] = "An error occurred while booking the appointment.";
                return RedirectToAction("Index", "Home");
            }
        }

        // Appointment details
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Patient)]
        public IActionResult Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var appointment = _unitOfWork.Appointment.Get(
                a => a.ID == id && (a.ApplicationUserId == userId || User.IsInRole(SD.Role_Admin)),
                includeProperties: "Nobet,Nobet.Assistant,Nobet.Department,ApplicationUser");

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // Cancel appointment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var appointment = _unitOfWork.Appointment.Get(
                a => a.ID == id && a.ApplicationUserId == userId);

            if (appointment == null)
            {
                return NotFound();
            }

            try
            {
                // Cancellation logic
                appointment.Status = AppointmentStatus.Cancelled;
                _unitOfWork.Appointment.Update(appointment);
                _unitOfWork.Save();

                // Release the Nobet slot
                await _appointmentService.ReleaseNobetSlot(appointment.NobetID);

                TempData["success"] = "Appointment cancelled successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["error"] = "Unable to cancel the appointment.";
                return RedirectToAction(nameof(Details), new { id });
            }
        }

        [HttpPost]
        public IActionResult DeleteAppointment(int id)
        {
            var appointment = _unitOfWork.Appointment.GetAll().FirstOrDefault(a => a.ID == id);
            if (appointment == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Appointment.Remove(appointment);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }

        // Admin Section - Manage appointments
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult AdminIndex()
        {
            var appointments = _unitOfWork.Appointment
                .GetAll(includeProperties: "Nobet,Nobet.Assistant,Nobet.Department,ApplicationUser")
                .OrderByDescending(a => a.Nobet.Date)
                .ToList();

            return View(appointments);
        }

        //[Authorize(Roles = SD.Role_Admin)]
        //[HttpPost]
        //public IActionResult DeleteAppointment(int id)
        //{
        //    var appointment = _unitOfWork.Appointment.GetAll().FirstOrDefault(a => a.ID == id);
        //    if (appointment == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }

        //    _unitOfWork.Appointment.Remove(appointment);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Delete successful" });
        //}

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult PendingAppointments()
        {
            var pendingAppointments = _unitOfWork.Appointment
                .GetAll(a => a.Status == AppointmentStatus.Pending,
                    includeProperties: "Nobet,Nobet.Assistant,Nobet.Department,ApplicationUser")
                .OrderByDescending(a => a.Nobet.Date)
                .ToList();

            return View(pendingAppointments);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(int id, AppointmentStatus status)
        {
            //var appointment = _unitOfWork.Appointment.Get(a => a.ID == id);

            //if (appointment == null)
            //{
            //    return NotFound();
            //}

            //appointment.Status = status;
            //_unitOfWork.Appointment.Update(appointment);
            //_unitOfWork.Save();

            //TempData["success"] = $"Appointment {status.ToString().ToLower()} successfully.";
            //return RedirectToAction(nameof(PendingAppointments));


            // Point de débogage
            System.Diagnostics.Debug.WriteLine($"UpdateStatus called with id={id} and status={status}");

            var appointment = _unitOfWork.Appointment.Get(a => a.ID == id);

            if (appointment == null)
            {
                return NotFound();
            }

            appointment.Status = status;
            _unitOfWork.Appointment.Update(appointment);
            _unitOfWork.Save();

            TempData["success"] = $"Appointment {status.ToString().ToLower()} successfully.";
            return RedirectToAction(nameof(PendingAppointments));
        }
    }
}