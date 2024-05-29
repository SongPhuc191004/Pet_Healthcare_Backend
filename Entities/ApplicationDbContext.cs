using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<PetVaccination> PetVaccinations { get; set; }
        public DbSet<PetHealthTrack> PetHealthTracks { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Kennel> Kennels { get; set; }
        public DbSet<Hospitalization> Hospitalizations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AppointmentDetail> AppointmentDetails { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vet>()
                .ToTable("Vet")
                .HasBaseType<User>();

            modelBuilder.Entity<Customer>()
                .ToTable("Customer")
                .HasBaseType<User>();

            // Disable cascading deletes for specific relationships
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Vet)
                .WithMany(v => v.Appointments)
                .HasForeignKey(a => a.VetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Hospitalization>()
                .HasOne(h => h.Vet)
                .WithMany(v => v.Hospitalizations)
                .HasForeignKey(h => h.VetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppointmentDetail>()
                .HasOne(ad => ad.Record)
                .WithMany(r => r.AppointmentDetails)
                .HasForeignKey(ad => ad.RecordId)
                .OnDelete(DeleteBehavior.Restrict);

            // Define composite keys
            modelBuilder.Entity<PetVaccination>()
                .HasKey(pv => new { pv.PetId, pv.VaccineId });

            modelBuilder.Entity<PetVaccination>()
                .HasOne(pv => pv.Pet)
                .WithMany(p => p.PetVaccinations)
                .HasForeignKey(pv => pv.PetId);

            modelBuilder.Entity<PetVaccination>()
                .HasOne(pv => pv.Vaccine)
                .WithMany(v => v.PetVaccinations)
                .HasForeignKey(pv => pv.VaccineId);

            // Define roles for AspNetRoles
            List<IdentityRole> identityRoles = new List<IdentityRole>()
            {
                new IdentityRole
                { 
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                },
                new IdentityRole
                {
                    Name = "Vet",
                    NormalizedName = "VET"
                },
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(identityRoles);

            #region Another Seed Data

            //modelBuilder.Entity<Appointment>().HasData(
            //    new Appointment { AppointmentId = 1, CustomerId = 1, PetId = 1, VetId = 4, SlotId = 1, ServiceId = 1, Date = DateOnly.Parse("2023-06-15"), TotalCost = 50.00, CancellationDate = null, RefundAmount = null, Rating = null, Comments = null, Status = AppointmentStatus.Boooked },
            //    new Appointment { AppointmentId = 2, CustomerId = 2, PetId = 2, VetId = 4, SlotId = 2, ServiceId = 2, Date = DateOnly.Parse("2023-07-01"), TotalCost = 30.00, CancellationDate = null, RefundAmount = null, Rating = null, Comments = null, Status = AppointmentStatus.Processing },
            //    new Appointment { AppointmentId = 3, CustomerId = 2, PetId = 3, VetId = 5, SlotId = 3, ServiceId = 3, Date = DateOnly.Parse("2023-08-10"), TotalCost = 40.00, CancellationDate = null, RefundAmount = null, Rating = 4, Comments = "Friendly staff, great service.", Status = AppointmentStatus.Done },
            //    new Appointment { AppointmentId = 4, CustomerId = 1, PetId = 4, VetId = 5, SlotId = 4, ServiceId = 4, Date = DateOnly.Parse("2023-09-01"), TotalCost = 75.00, CancellationDate = null, RefundAmount = null, Rating = null, Comments = null, Status = AppointmentStatus.Boooked },
            //    new Appointment { AppointmentId = 5, CustomerId = 1, PetId = 5, VetId = 4, SlotId = 5, ServiceId = 1, Date = DateOnly.Parse("2023-10-15"), TotalCost = 500.00, CancellationDate = null, RefundAmount = null, Rating = null, Comments = null, Status = AppointmentStatus.Boooked }
            //);

            //modelBuilder.Entity<AppointmentDetail>().HasData(
            //    new AppointmentDetail { AppointmentDetailId = 1, AppointmentId = 1, RecordId = 1, Diagnosis = "Healthy", Treatment = null, Medication = null },
            //    new AppointmentDetail { AppointmentDetailId = 2, AppointmentId = 2, RecordId = 2, Diagnosis = "Ear Infection", Treatment = "Antibiotic Ear Drops", Medication = "Otomax Otic Solution" },
            //    new AppointmentDetail { AppointmentDetailId = 3, AppointmentId = 3, RecordId = 3, Diagnosis = "Feather Plucking", Treatment = "Environmental Enrichment", Medication = null },
            //    new AppointmentDetail { AppointmentDetailId = 4, AppointmentId = 4, RecordId = 4, Diagnosis = "Swim Bladder Disorder", Treatment = "Medication and Diet Change", Medication = "Antibiotics and Anti-inflammatory" },
            //    new AppointmentDetail { AppointmentDetailId = 5, AppointmentId = 5, RecordId = 5, Diagnosis = "Gastrointestinal Stasis", Treatment = "Motility Medication and Massage", Medication = "CisaprIde and Simethicone" }
            //);

            //modelBuilder.Entity<Hospitalization>().HasData(
            //    new Hospitalization { HospitalizationId = 1, PetId = 1, KennelId = 1, VetId = 4, AdmissionDate = DateOnly.Parse("2023-05-01"), DischargeDate = DateOnly.Parse("2023-05-05"), TotalCost = 125.00 },
            //    new Hospitalization { HospitalizationId = 2, PetId = 2, KennelId = 2, VetId = 4, AdmissionDate = DateOnly.Parse("2023-06-10"), DischargeDate = DateOnly.Parse("2023-06-12"), TotalCost = 120.00 },
            //    new Hospitalization { HospitalizationId = 3, PetId = 3, KennelId = 3, VetId = 5, AdmissionDate = DateOnly.Parse("2023-07-15"), DischargeDate = DateOnly.Parse("2023-07-18"), TotalCost = 60.00 },
            //    new Hospitalization { HospitalizationId = 4, PetId = 4, KennelId = 4, VetId = 5, AdmissionDate = DateOnly.Parse("2023-08-01"), DischargeDate = DateOnly.Parse("2023-08-03"), TotalCost = 90.00 },
            //    new Hospitalization { HospitalizationId = 5, PetId = 5, KennelId = 5, VetId = 5, AdmissionDate = DateOnly.Parse("2023-09-10"), DischargeDate = DateOnly.Parse("2023-09-12"), TotalCost = 105.00 }
            //);

            //modelBuilder.Entity<Kennel>().HasData(
            //    new Kennel { KennelId = 1, Description = "Comfortable and secure kennel for your pet.", Capacity = 20, DailyCost = 25.00 },
            //    new Kennel { KennelId = 2, Description = "Luxury kennel with premium amenities.", Capacity = 10, DailyCost = 40.00 },
            //    new Kennel { KennelId = 3, Description = "Budget-friendly kennel for short-term stays.", Capacity = 30, DailyCost = 15.00 },
            //    new Kennel { KennelId = 4, Description = "Large kennel with outdoor play area.", Capacity = 25, DailyCost = 30.00 },
            //    new Kennel { KennelId = 5, Description = "Climate-controlled kennel for exotic pets.", Capacity = 15, DailyCost = 35.00 }
            //);

            //modelBuilder.Entity<Pet>().HasData(
            //    new Pet { PetId = 1, CustomerId = 1, Name = "Buddy", Species = "Dog", Breed = "Labrador Retriever", Gender = true, Weight = 30.5, ImageURL = "https://example.com/pet_images/buddy.jpg" },
            //    new Pet { PetId = 2, CustomerId = 2, Name = "Whiskers", Species = "Cat", Breed = "Siamese", Gender = false, Weight = 4.2, ImageURL = "https://example.com/pet_images/whiskers.jpg" },
            //    new Pet { PetId = 3, CustomerId = 2, Name = "Rocky", Species = "Bird", Breed = "Cockatiel", Gender = true, Weight = 0.3, ImageURL = "https://example.com/pet_images/rocky.jpg" },
            //    new Pet { PetId = 4, CustomerId = 1, Name = "Finny", Species = "Fish", Breed = "Goldfish", Gender = false, Weight = 0.1, ImageURL = "https://example.com/pet_images/finny.jpg" },
            //    new Pet { PetId = 5, CustomerId = 1, Name = "Fluffy", Species = "Rabbit", Breed = "Lop", Gender = true, Weight = 2.8, ImageURL = "https://example.com/pet_images/fluffy.jpg" }
            //);

            //modelBuilder.Entity<PetHealthTrack>().HasData(
            //    new PetHealthTrack { PetHealthTrackId = 1, HospitalizationId = 1, Description = "Recovering from surgery", Date = DateOnly.Parse("2023-05-03"), Status = PetStatus.Severe },
            //    new PetHealthTrack { PetHealthTrackId = 2, HospitalizationId = 2, Description = "Monitoring for dehydration", Date = DateOnly.Parse("2023-06-11"), Status = PetStatus.Recovering },
            //    new PetHealthTrack { PetHealthTrackId = 3, HospitalizationId = 3, Description = "Treating respiratory infection", Date = DateOnly.Parse("2023-07-16"), Status = PetStatus.Normal },
            //    new PetHealthTrack { PetHealthTrackId = 4, HospitalizationId = 4, Description = "Observing swim bladder disorder", Date = DateOnly.Parse("2023-08-02"), Status = PetStatus.Severe },
            //    new PetHealthTrack { PetHealthTrackId = 5, HospitalizationId = 5, Description = "Managing gastrointestinal stasis", Date = DateOnly.Parse("2023-09-11"), Status = PetStatus.Recovering }
            //);

            //modelBuilder.Entity<PetVaccination>().HasData(
            //    new PetVaccination { PetId = 1, VaccineId = 1, VaccinationDate = DateOnly.Parse("2023-04-01") },
            //    new PetVaccination { PetId = 1, VaccineId = 2, VaccinationDate = DateOnly.Parse("2022-08-15") },
            //    new PetVaccination { PetId = 2, VaccineId = 3, VaccinationDate = DateOnly.Parse("2023-03-01") },
            //    new PetVaccination { PetId = 1, VaccineId = 4, VaccinationDate = DateOnly.Parse("2023-01-10") },
            //    new PetVaccination { PetId = 3, VaccineId = 5, VaccinationDate = DateOnly.Parse("2023-02-20") }
            //);

            //modelBuilder.Entity<Record>().HasData(
            //    new Record { RecordId = 1, PetId = 1, NumberOfVisits = 1 },
            //    new Record { RecordId = 2, PetId = 2, NumberOfVisits = 1 },
            //    new Record { RecordId = 3, PetId = 3, NumberOfVisits = 1 },
            //    new Record { RecordId = 4, PetId = 4, NumberOfVisits = 1 },
            //    new Record { RecordId = 5, PetId = 5, NumberOfVisits = 1 }
            //);

            //modelBuilder.Entity<Service>().HasData(
            //    new Service { ServiceId = 1, Name = "Annual Check-Up", Description = "Comprehensive health check-up for your pet.", Cost = 50.00 },
            //    new Service { ServiceId = 2, Name = "Vaccination", Description = "Essential vaccines to keep your pet healthy.", Cost = 30.00 },
            //    new Service { ServiceId = 3, Name = "Behavioral Consultation", Description = "Addressing behavioral issues with your pet.", Cost = 40.00 },
            //    new Service { ServiceId = 4, Name = "Specialized Surgery", Description = "Advanced surgical procedures for complex conditions.", Cost = 75.00 }
            //);

            //modelBuilder.Entity<Slot>().HasData(
            //    new Slot { SlotId = 1, StartTime = TimeOnly.Parse("09:00"), EndTime = TimeOnly.Parse("10:00") },
            //    new Slot { SlotId = 2, StartTime = TimeOnly.Parse("10:00"), EndTime = TimeOnly.Parse("11:00") },
            //    new Slot { SlotId = 3, StartTime = TimeOnly.Parse("11:00"), EndTime = TimeOnly.Parse("12:00") },
            //    new Slot { SlotId = 4, StartTime = TimeOnly.Parse("12:00"), EndTime = TimeOnly.Parse("13:00") },
            //    new Slot { SlotId = 5, StartTime = TimeOnly.Parse("13:00"), EndTime = TimeOnly.Parse("14:00") },
            //    new Slot { SlotId = 6, StartTime = TimeOnly.Parse("14:00"), EndTime = TimeOnly.Parse("15:00") },
            //    new Slot { SlotId = 7, StartTime = TimeOnly.Parse("15:00"), EndTime = TimeOnly.Parse("16:00") }
            //);

            //modelBuilder.Entity<Vaccine>().HasData(
            //    new Vaccine { VaccineId = 1, Name = "Rabies Vaccine", Description = "Prevents rabies infection." },
            //    new Vaccine { VaccineId = 2, Name = "Distemper Vaccine", Description = "Prevents canine distemper." },
            //    new Vaccine { VaccineId = 3, Name = "Feline Leukemia Vaccine", Description = "Prevents feline leukemia." },
            //    new Vaccine { VaccineId = 4, Name = "Parvovirus Vaccine", Description = "Prevents canine parvovirus." },
            //    new Vaccine { VaccineId = 5, Name = "Avian Influenza Vaccine", Description = "Prevents avian influenza." }
            //);

            //modelBuilder.Entity<Vet>().HasData(
            //    new Vet
            //    {
            //        FirstName = "Emily",
            //        LastName = "Wilson",
            //        Gender = false,
            //        Email = "emily.wilson@example.com",
            //        UserName = "ewilson",
            //        Password = "password321",
            //        Address = "456 Pine Ave, Anytown USA",
            //        Country = "United States",
            //        ImageURL = "https://example.com/user_images/ewilson.jpg",
            //        IsActive = true,
            //        Rating = 4,
            //        YearsOfExperience = 10
            //    },
            //    new Vet
            //    {
            //        FirstName = "Michael",
            //        LastName = "Brown",
            //        Gender = true,
            //        Email = "michael.brown@example.com",
            //        UserName = "mbrown",
            //        Password = "password654",
            //        Address = "789 Maple Ln, Anytown USA",
            //        Country = "United States",
            //        ImageURL = "https://example.com/user_images/mbrown.jpg",
            //        IsActive = true,
            //        Rating = 5,
            //        YearsOfExperience = 7
            //    }
            //    );

            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        FirstName = "Bob",
            //        LastName = "Johnson",
            //        Gender = true,
            //        Email = "bob.johnson@example.com",
            //        UserName = "bjohnson",
            //        Password = "password789",
            //        Address = "789 Elm St, Anytown USA",
            //        Country = "United States",
            //        ImageURL = "https://example.com/user_images/bjohnson.jpg",
            //        IsActive = true
            //    }
            //);

            //modelBuilder.Entity<Customer>().HasData(
            //    new Customer
            //    {
            //        FirstName = "John",
            //        LastName = "Doe",
            //        Gender = true,
            //        Email = "john.doe@example.com",
            //        UserName = "jdoe",
            //        Password = "password123",
            //        Address = "123 Main St, Anytown USA",
            //        Country = "United States",
            //        ImageURL = "https://example.com/user_images/jdoe.jpg",
            //        IsActive = true,
            //    },
            //    new Customer
            //    {
            //        FirstName = "Jane",
            //        LastName = "Smith",
            //        Gender = false,
            //        Email = "jane.smith@example.com",
            //        UserName = "jsmith",
            //        Password = "password456",
            //        Address = "456 Oak Rd, Anytown USA",
            //        Country = "United States",
            //        ImageURL = "https://example.com/user_images/jsmith.jpg",
            //        IsActive = true
            //    }
            //);

            #endregion
        }
    }
}