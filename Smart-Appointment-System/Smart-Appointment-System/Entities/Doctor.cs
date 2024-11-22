using System;
using System.Collections.Generic;

namespace Smart_Appointment_System.Entities;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public int Price { get; set; }
     
    public string Category { get; set; } = "General";


    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
