﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PediGuard.Helper;
using PediGuard.Models;
using PediGuard.Models.ViewModels;
using PediGuard.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PediGuard.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmergencyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly EmailService _emailService;

        public EmergencyController(IUnitOfWork unitOfWork/*, EmailService emailService*/)
        {
            _unitOfWork = unitOfWork;
            //_emailService = emailService;
        }

        public IActionResult Index()
        {
            List<Emergency> objEmergencyList = _unitOfWork.Emergency
                .GetAll(includeProperties: "Department")
                .ToList();
            return View(objEmergencyList);
        }

        public IActionResult Upsert(int? id)
        {
            EmergencyVM emergencyVM = new()
            {
                DepartmentList = _unitOfWork.Department.GetAll().Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }),
                Emergency = new Emergency()
            };

            if (id == null || id == 0)
            {
                return View(emergencyVM);
            }
            else
            {
                emergencyVM.Emergency = _unitOfWork.Emergency.Get(u => u.Id == id);
                return View(emergencyVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(EmergencyVM emergencyVM)
        {
            if (ModelState.IsValid)
            {
                if (emergencyVM.Emergency.Id == 0)
                {
                    emergencyVM.Emergency.CreatedAt = DateTime.Now;
                    emergencyVM.Emergency.UpdatedAt = DateTime.Now;
                    emergencyVM.Emergency.Status = "Pending";
                    emergencyVM.Emergency.CreatedAt = DateTime.Now;
                    emergencyVM.Emergency.UpdatedAt = DateTime.Now;
                    _unitOfWork.Emergency.Add(emergencyVM.Emergency);

                    // Envoyer des emails à tous les assistants
                    var assistants = _unitOfWork.Assistant.GetAll().ToList();
                    foreach (var assistant in assistants)
                    {
                        var subject = "Urgence: " + emergencyVM.Emergency.Description;
                        var message = $"There is a new emergency.<br>Description: {emergencyVM.Emergency.Description}<br>Date et Heure: {emergencyVM.Emergency.CreatedAt}<br>Lieu: {emergencyVM.Emergency.Location}";
                        //await _emailService.SendEmailAsync(assistant.Email, subject, message);
                    }
                }
                else
                {
                    var existingEmergency = _unitOfWork.Emergency.Get(u => u.Id == emergencyVM.Emergency.Id);
                    if (existingEmergency != null)
                    {
                        existingEmergency.Description = emergencyVM.Emergency.Description;
                        existingEmergency.Location = emergencyVM.Emergency.Location;
                        existingEmergency.Status = emergencyVM.Emergency.Status;
                        existingEmergency.DepartmentId = emergencyVM.Emergency.DepartmentId;
                        existingEmergency.UpdatedAt = DateTime.Now;

                        _unitOfWork.Emergency.Update(existingEmergency);
                    }
                }

                _unitOfWork.Save();
                TempData["success"] = "Emergency created/updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                emergencyVM.DepartmentList = _unitOfWork.Department.GetAll().Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                });

                return View(emergencyVM);
            }
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Emergency> objEmergencyList = _unitOfWork.Emergency
            .GetAll(includeProperties: "Department")
            .ToList();
            return Json(new { data = objEmergencyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(new { success = false, message = "ID is required" });
            }

            var EmergencyToBeDeleted = _unitOfWork.Emergency.Get(u => u.Id == id);

            if (EmergencyToBeDeleted == null)
            {
                return NotFound(new { success = false, message = "Record not found" });
            }

            _unitOfWork.Emergency.Remove(EmergencyToBeDeleted);
            _unitOfWork.Save();

            return Ok(new { success = true, message = "Delete successful" });
        }

        
        #endregion
    }
}