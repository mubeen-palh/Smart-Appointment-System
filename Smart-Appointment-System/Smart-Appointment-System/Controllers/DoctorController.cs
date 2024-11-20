﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Appointment_System.DTOs;
using Smart_Appointment_System.Entities;
using System.Text;

namespace Smart_Appointment_System.Controllers
{

    [ApiController]
    public class DoctorController : ControllerBase
    {

        private readonly ILogger<DoctorController> _logger;
        private readonly SmartAppointmentContext _context;

        public DoctorController(ILogger<DoctorController> logger, SmartAppointmentContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("api/[controller]/getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var doctors = await _context.Doctors.
                            ToListAsync();

            return Ok(doctors);
        }


        [HttpPost]
        [Route("api/[controller]/register")]
        public IActionResult Add([FromBody] DoctorRequestDTO doctorRequest)
        {
            try
            {
                // Check if the email already exists
                var existingDoctor = _context.Doctors.FirstOrDefault(d => d.Email == doctorRequest.Email);
                if (existingDoctor != null)
                {
                    return BadRequest("Email already exists. Please use a different email.");
                }

                // Hash the password before saving
                var hashedPassword = HashPassword(doctorRequest.Password);

                var record = new Doctor
                {
                    Email = doctorRequest.Email,
                    Password = hashedPassword, // Save the hashed password
                    FullName = doctorRequest.FullName,
                    Price = doctorRequest.Price,
                };

                _context.Doctors.Add(record);
                _context.SaveChanges();
                return Ok("Doctor registered successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the doctor.");
                return StatusCode(500, "Internal server error");
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }



    }
}
