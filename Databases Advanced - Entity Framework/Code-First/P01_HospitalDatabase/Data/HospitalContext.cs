﻿using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
            if (modelBuilder.IsConfigured == false)
            {
                string connection =
                    "server=DESKTOP-4FKVBUR\\SQLEXPRESS;" +
                    "database=Hospital;" +
                    "integrated security=true";
                modelBuilder.UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50);

                entity.Property(e => e.Address)
                    .HasMaxLength(520);

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.HasInsurance)
                    .HasDefaultValue(1);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(true);

                entity.Property(e => e.Specialty)
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.HasKey(e => e.DiagnoseId);

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Diagnoses);

                entity.Property(e => e.Name)
                    .HasMaxLength(50);

                entity.Property(e => e.Comments)
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.HasKey(e => e.VisitationId);

                entity.HasOne(e => e.Patient)
                   .WithMany(p => p.Visitations)
                   .HasForeignKey(e => e.PatientId);

                entity.HasOne(e => e.Doctor)
                    .WithMany(d => d.Visitations)
                    .HasForeignKey(e => e.DoctorId);

                entity.Property(e => e.Comments)
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(e => new { e.MedicamentId, e.PatientId });

                entity.HasOne(e => e.Medicament)
                    .WithMany(m => m.Prescriptions)
                    .HasForeignKey(e => e.MedicamentId);

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(e => e.PatientId);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.MedicamentId);

                entity.Property(e => e.Name)
                    .HasMaxLength(50);
            });
        }
    }
}
