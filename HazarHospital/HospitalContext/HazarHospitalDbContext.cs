﻿using HazarHospital.Entities;
using Microsoft.EntityFrameworkCore;

namespace HazarHospital.HospitalContext
{
    public class HazarHospitalDbContext : DbContext
    {
        public HazarHospitalDbContext(DbContextOptions<HazarHospitalDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
               .HasOne(p => p.MedicalRecord)
               .WithOne(m => m.Patient)
               .HasForeignKey<MedicalRecord>(p => p.PatientId);


            modelBuilder.Entity<User>()
                .HasOne(u => u.Admin)
                .WithOne(a => a.User)
                .HasForeignKey<Admin>(a => a.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Patient)
                .WithOne(p => p.User)
                .HasForeignKey<Patient>(p => p.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Doctor)
                .WithOne(d => d.User)
                .HasForeignKey<Doctor>(d => d.UserId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Packing>()
                .HasOne(Parking => Parking.Appointment)
                .WithOne(a => a.PackingSpace)
                .HasForeignKey<Appointment>(p => p.ParkingId);

            modelBuilder.Entity<Packing>()
                .HasIndex(p => p.PackingNo)
                .IsUnique();

            modelBuilder.Entity<Packing>()
                .Property(P => P.PackingNo)
                .IsRequired();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Packing> Packings { get; set; }
        public DbSet<MedicalRecord> AppointmentsRecords { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
    }
}
