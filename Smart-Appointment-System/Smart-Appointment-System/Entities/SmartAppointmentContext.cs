using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Smart_Appointment_System.Entities;

public partial class SmartAppointmentContext : DbContext
{
    public SmartAppointmentContext()
    {
    }

    public SmartAppointmentContext(DbContextOptions<SmartAppointmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=SmartAppointment;Username=postgres;Password=heyitsme");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("Bookings_pkey");

            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.BookingTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DoctorsDoctorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Doctors_doctor_id");
            entity.Property(e => e.PatientsPatientId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Patients_patient_id");

            entity.HasOne(d => d.DoctorsDoctor).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.DoctorsDoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Bookings_Doctors_doctor_id_fkey");

            entity.HasOne(d => d.PatientsPatient).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.PatientsPatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Bookings_Patients_patient_id_fkey");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("Doctors_pkey");

            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("Patients_pkey");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("Reviews_pkey");

            entity.Property(e => e.ReviewId).HasColumnName("review_id");
            entity.Property(e => e.BookingId)
                .ValueGeneratedOnAdd()
                .HasColumnName("booking_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Stars).HasColumnName("stars");

            entity.HasOne(d => d.Booking).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("booking_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
