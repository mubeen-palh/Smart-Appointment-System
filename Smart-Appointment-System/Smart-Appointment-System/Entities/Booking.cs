using System;
using System.Collections.Generic;

namespace Smart_Appointment_System.Entities;

public partial class Booking
{
    public int DoctorsDoctorId { get; set; }

    public int PatientsPatientId { get; set; }

    public int BookingId { get; set; }

    public string? Description { get; set; }

    public DateTime BookingTime { get; set; }

    public virtual Doctor DoctorsDoctor { get; set; } = null!;

    public virtual Patient PatientsPatient { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
