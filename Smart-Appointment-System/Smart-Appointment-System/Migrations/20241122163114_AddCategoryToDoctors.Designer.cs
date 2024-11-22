﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Smart_Appointment_System.Entities;

#nullable disable

namespace Smart_Appointment_System.Migrations
{
    [DbContext(typeof(SmartAppointmentContext))]
    [Migration("20241122163114_AddCategoryToDoctors")]
    partial class AddCategoryToDoctors
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Smart_Appointment_System.Entities.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("booking_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("BookingTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("DoctorsDoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Doctors_doctor_id");

                    b.Property<int>("PatientsPatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Patients_patient_id");

                    b.HasKey("BookingId")
                        .HasName("Bookings_pkey");

                    b.HasIndex("DoctorsDoctorId");

                    b.HasIndex("PatientsPatientId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Smart_Appointment_System.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("doctor_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DoctorId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("full_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("password");

                    b.Property<int>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("price");

                    b.HasKey("DoctorId")
                        .HasName("Doctors_pkey");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Smart_Appointment_System.Entities.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PatientId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("full_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("password");

                    b.HasKey("PatientId")
                        .HasName("Patients_pkey");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Smart_Appointment_System.Entities.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("review_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReviewId"));

                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("booking_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("Stars")
                        .HasColumnType("integer")
                        .HasColumnName("stars");

                    b.HasKey("ReviewId")
                        .HasName("Reviews_pkey");

                    b.HasIndex("BookingId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Smart_Appointment_System.Entities.Booking", b =>
                {
                    b.HasOne("Smart_Appointment_System.Entities.Doctor", "DoctorsDoctor")
                        .WithMany("Bookings")
                        .HasForeignKey("DoctorsDoctorId")
                        .IsRequired()
                        .HasConstraintName("Bookings_Doctors_doctor_id_fkey");

                    b.HasOne("Smart_Appointment_System.Entities.Patient", "PatientsPatient")
                        .WithMany("Bookings")
                        .HasForeignKey("PatientsPatientId")
                        .IsRequired()
                        .HasConstraintName("Bookings_Patients_patient_id_fkey");

                    b.Navigation("DoctorsDoctor");

                    b.Navigation("PatientsPatient");
                });

            modelBuilder.Entity("Smart_Appointment_System.Entities.Review", b =>
                {
                    b.HasOne("Smart_Appointment_System.Entities.Booking", "Booking")
                        .WithMany("Reviews")
                        .HasForeignKey("BookingId")
                        .IsRequired()
                        .HasConstraintName("booking_id");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Smart_Appointment_System.Entities.Booking", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Smart_Appointment_System.Entities.Doctor", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Smart_Appointment_System.Entities.Patient", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
