using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Appointment_System.Entities;
using Smart_Appointment_System.Authentication;
using System.Security.Cryptography;
using System.Text;
using Smart_Appointment_System.DTOs;
namespace Smart_Appointment_System.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly SmartAppointmentContext _context;
        private readonly TokenService _tokenService;

        public LoginController(ILogger<LoginController> logger, SmartAppointmentContext context, TokenService tokenService)
        {
            _logger = logger;
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("api/[controller]/doctor")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            try
            {
                // Hash the incoming password for comparison
                var hashedPassword = HashPassword(request.Password);

                // Query the Doctors table to find a match
                var doctor = await _context.Doctors
                    .FirstOrDefaultAsync(d => d.Email == request.Email && d.Password == hashedPassword);

                if (doctor == null)
                {
                    return Unauthorized("Invalid email or password.");
                }

                // Generate JWT token
                var token = _tokenService.GenerateToken(doctor.DoctorId.ToString(), doctor.Email);

                // Return the token and doctor info
                return Ok(new
                {
                    Token = token,
                    DoctorId = doctor.DoctorId,
                    FullName = doctor.FullName,
                    Email = doctor.Email
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during login.");
                return StatusCode(500, "Internal server error.");
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }

}
