﻿// <auto-generated />
using System;
using HazarHospital.HospitalContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HazarHospital.Migrations
{
    [DbContext(typeof(HazarHospitalDbContext))]
    [Migration("20221227222319_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HazarHospital.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdminCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("HazarHospital.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("AppointmentDuration")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("AppointmentReason")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AppointmentReferenceNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DoctorComment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDriving")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("MedicalRecordId")
                        .HasColumnType("int");

                    b.Property<int?>("ParkingId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("MedicalRecordId");

                    b.HasIndex("ParkingId")
                        .IsUnique();

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HazarHospital.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DoctorCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DoctorProffession")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LabResult")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TotalHoursOfWork")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HazarHospital.Entities.MedicalRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("MedicalRecord");
                });

            modelBuilder.Entity("HazarHospital.Entities.Packing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsAssigned")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PackingNo")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("PackingNo")
                        .IsUnique();

                    b.ToTable("Packings");
                });

            modelBuilder.Entity("HazarHospital.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PatientAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PatientCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double?>("PhoneNumber")
                        .HasColumnType("double");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HazarHospital.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HazarHospital.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("HashSalt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HazarHospital.Entities.Admin", b =>
                {
                    b.HasOne("HazarHospital.Entities.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("HazarHospital.Entities.Admin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HazarHospital.Entities.Appointment", b =>
                {
                    b.HasOne("HazarHospital.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId");

                    b.HasOne("HazarHospital.Entities.MedicalRecord", null)
                        .WithMany("Appointments")
                        .HasForeignKey("MedicalRecordId");

                    b.HasOne("HazarHospital.Entities.Packing", "PackingSpace")
                        .WithOne("Appointment")
                        .HasForeignKey("HazarHospital.Entities.Appointment", "ParkingId");

                    b.HasOne("HazarHospital.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("PackingSpace");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HazarHospital.Entities.Doctor", b =>
                {
                    b.HasOne("HazarHospital.Entities.User", "User")
                        .WithOne("Doctor")
                        .HasForeignKey("HazarHospital.Entities.Doctor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HazarHospital.Entities.MedicalRecord", b =>
                {
                    b.HasOne("HazarHospital.Entities.Patient", "Patient")
                        .WithOne("MedicalRecord")
                        .HasForeignKey("HazarHospital.Entities.MedicalRecord", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HazarHospital.Entities.Patient", b =>
                {
                    b.HasOne("HazarHospital.Entities.User", "User")
                        .WithOne("Patient")
                        .HasForeignKey("HazarHospital.Entities.Patient", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HazarHospital.Entities.User", b =>
                {
                    b.HasOne("HazarHospital.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HazarHospital.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("HazarHospital.Entities.MedicalRecord", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("HazarHospital.Entities.Packing", b =>
                {
                    b.Navigation("Appointment")
                        .IsRequired();
                });

            modelBuilder.Entity("HazarHospital.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("MedicalRecord")
                        .IsRequired();
                });

            modelBuilder.Entity("HazarHospital.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("HazarHospital.Entities.User", b =>
                {
                    b.Navigation("Admin")
                        .IsRequired();

                    b.Navigation("Doctor")
                        .IsRequired();

                    b.Navigation("Patient")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
