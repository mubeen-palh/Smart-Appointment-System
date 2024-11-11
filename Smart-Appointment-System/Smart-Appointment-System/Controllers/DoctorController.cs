using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Appointment_System.DTOs;
using Smart_Appointment_System.Entities;

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
        [Route("api/[controller]/")]
        public IActionResult Add([FromBody] DoctorRequestDTO doctorRequest)
        {
            try
            {
                var record = new Doctor
                {
                    Email = doctorRequest.Email,
                    Password = doctorRequest.Password,
                    FullName = doctorRequest.FullName,
                    Price = doctorRequest.Price,
                };
                _context.Doctors.Add(record);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the doctors.");
                return StatusCode(500, "Internal server error");
            }

        }



    }
}
