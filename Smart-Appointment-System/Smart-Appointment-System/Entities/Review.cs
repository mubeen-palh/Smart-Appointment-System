using System;
using System.Collections.Generic;

namespace Smart_Appointment_System.Entities;

public partial class Review
{
    public int ReviewId { get; set; }

    public string Description { get; set; } = null!;

    public int Stars { get; set; }

    public int BookingId { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
