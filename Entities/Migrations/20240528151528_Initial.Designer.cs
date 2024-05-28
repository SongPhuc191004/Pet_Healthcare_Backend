﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240528151528_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<DateOnly?>("CancellationDate")
                        .HasColumnType("date");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly?>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("PetId")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<double?>("RefundAmount")
                        .HasColumnType("float");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("SlotId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double?>("TotalCost")
                        .HasColumnType("float");

                    b.Property<string>("VetId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AppointmentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PetId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("SlotId");

                    b.HasIndex("VetId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("Entities.AppointmentDetail", b =>
                {
                    b.Property<int>("AppointmentDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentDetailId"));

                    b.Property<int?>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medication")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecordId")
                        .HasColumnType("int");

                    b.Property<string>("Treatment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppointmentDetailId");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("RecordId");

                    b.ToTable("AppointmentDetail");
                });

            modelBuilder.Entity("Entities.Hospitalization", b =>
                {
                    b.Property<int>("HospitalizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HospitalizationId"));

                    b.Property<DateOnly?>("AdmissionDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DischargeDate")
                        .HasColumnType("date");

                    b.Property<int?>("KennelId")
                        .HasColumnType("int");

                    b.Property<int?>("PetId")
                        .HasColumnType("int");

                    b.Property<double?>("TotalCost")
                        .HasColumnType("float");

                    b.Property<string>("VetId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("HospitalizationId");

                    b.HasIndex("KennelId");

                    b.HasIndex("PetId");

                    b.HasIndex("VetId");

                    b.ToTable("Hospitalization");
                });

            modelBuilder.Entity("Entities.Kennel", b =>
                {
                    b.Property<int>("KennelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KennelId"));

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<double?>("DailyCost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KennelId");

                    b.ToTable("Kennel");
                });

            modelBuilder.Entity("Entities.Pet", b =>
                {
                    b.Property<int>("PetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PetId"));

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Species")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("PetId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("Entities.PetHealthTrack", b =>
                {
                    b.Property<int>("PetHealthTrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PetHealthTrackId"));

                    b.Property<DateOnly?>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HospitalizationId")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("PetHealthTrackId");

                    b.HasIndex("HospitalizationId");

                    b.ToTable("PetHealthTrack");
                });

            modelBuilder.Entity("Entities.PetVaccination", b =>
                {
                    b.Property<int?>("PetId")
                        .HasColumnType("int");

                    b.Property<int?>("VaccineId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("VaccinationDate")
                        .HasColumnType("date");

                    b.HasKey("PetId", "VaccineId");

                    b.HasIndex("VaccineId");

                    b.ToTable("PetVaccination");
                });

            modelBuilder.Entity("Entities.Record", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecordId"));

                    b.Property<int?>("NumberOfVisits")
                        .HasColumnType("int");

                    b.Property<int?>("PetId")
                        .HasColumnType("int");

                    b.HasKey("RecordId");

                    b.HasIndex("PetId");

                    b.ToTable("Record");
                });

            modelBuilder.Entity("Entities.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<double?>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Entities.Slot", b =>
                {
                    b.Property<int>("SlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SlotId"));

                    b.Property<TimeOnly?>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeOnly?>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("SlotId");

                    b.ToTable("Slot");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Entities.Vaccine", b =>
                {
                    b.Property<int>("VaccineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VaccineId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsAnnualVaccine")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VaccineId");

                    b.ToTable("Vaccine");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "bbcac0cf-bc13-43b1-9b44-e2978916acac",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "3f5e4236-c7ce-4c0b-b352-05c6c82bb630",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        },
                        new
                        {
                            Id = "60edf088-fd2c-47c4-a07c-1f583015ac43",
                            Name = "Vet",
                            NormalizedName = "VET"
                        },
                        new
                        {
                            Id = "b90340c2-bdef-4788-95ef-5b147ed6b337",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entities.Customer", b =>
                {
                    b.HasBaseType("Entities.User");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Entities.Vet", b =>
                {
                    b.HasBaseType("Entities.User");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("YearsOfExperience")
                        .HasColumnType("int");

                    b.ToTable("Vet", (string)null);
                });

            modelBuilder.Entity("Entities.Appointment", b =>
                {
                    b.HasOne("Entities.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Pet", "Pet")
                        .WithMany("Appointments")
                        .HasForeignKey("PetId");

                    b.HasOne("Entities.Service", "Service")
                        .WithMany("Appointments")
                        .HasForeignKey("ServiceId");

                    b.HasOne("Entities.Slot", "Slot")
                        .WithMany("Appointments")
                        .HasForeignKey("SlotId");

                    b.HasOne("Entities.Vet", "Vet")
                        .WithMany("Appointments")
                        .HasForeignKey("VetId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Customer");

                    b.Navigation("Pet");

                    b.Navigation("Service");

                    b.Navigation("Slot");

                    b.Navigation("Vet");
                });

            modelBuilder.Entity("Entities.AppointmentDetail", b =>
                {
                    b.HasOne("Entities.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId");

                    b.HasOne("Entities.Record", "Record")
                        .WithMany("AppointmentDetails")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Appointment");

                    b.Navigation("Record");
                });

            modelBuilder.Entity("Entities.Hospitalization", b =>
                {
                    b.HasOne("Entities.Kennel", "Kennel")
                        .WithMany("Hospitalizations")
                        .HasForeignKey("KennelId");

                    b.HasOne("Entities.Pet", "Pet")
                        .WithMany("Hospitalizations")
                        .HasForeignKey("PetId");

                    b.HasOne("Entities.Vet", "Vet")
                        .WithMany("Hospitalizations")
                        .HasForeignKey("VetId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Kennel");

                    b.Navigation("Pet");

                    b.Navigation("Vet");
                });

            modelBuilder.Entity("Entities.Pet", b =>
                {
                    b.HasOne("Entities.Customer", "Customer")
                        .WithMany("Pets")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Entities.PetHealthTrack", b =>
                {
                    b.HasOne("Entities.Hospitalization", "Hospitalization")
                        .WithMany("PetHealthTracks")
                        .HasForeignKey("HospitalizationId");

                    b.Navigation("Hospitalization");
                });

            modelBuilder.Entity("Entities.PetVaccination", b =>
                {
                    b.HasOne("Entities.Pet", "Pet")
                        .WithMany("PetVaccinations")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Vaccine", "Vaccine")
                        .WithMany("PetVaccinations")
                        .HasForeignKey("VaccineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("Vaccine");
                });

            modelBuilder.Entity("Entities.Record", b =>
                {
                    b.HasOne("Entities.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Customer", b =>
                {
                    b.HasOne("Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Entities.Customer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Vet", b =>
                {
                    b.HasOne("Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Entities.Vet", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Hospitalization", b =>
                {
                    b.Navigation("PetHealthTracks");
                });

            modelBuilder.Entity("Entities.Kennel", b =>
                {
                    b.Navigation("Hospitalizations");
                });

            modelBuilder.Entity("Entities.Pet", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Hospitalizations");

                    b.Navigation("PetVaccinations");
                });

            modelBuilder.Entity("Entities.Record", b =>
                {
                    b.Navigation("AppointmentDetails");
                });

            modelBuilder.Entity("Entities.Service", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Entities.Slot", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Entities.Vaccine", b =>
                {
                    b.Navigation("PetVaccinations");
                });

            modelBuilder.Entity("Entities.Customer", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Entities.Vet", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Hospitalizations");
                });
#pragma warning restore 612, 618
        }
    }
}
