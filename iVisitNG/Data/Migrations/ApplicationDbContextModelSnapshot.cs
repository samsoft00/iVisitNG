﻿// <auto-generated />
using iVisitNG.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace iVisitNG.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("iVisitNG.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ApprovedStatus");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<int?>("FloorNumber");

                    b.Property<string>("InstructionToSecurity")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<bool>("IsGroupVisit");

                    b.Property<int>("PurposeOfVisitId");

                    b.Property<string>("StaffId")
                        .IsRequired();

                    b.Property<DateTime>("UpdateAt");

                    b.Property<int>("VisitorId");

                    b.Property<string>("barcode");

                    b.HasKey("Id");

                    b.HasIndex("PurposeOfVisitId");

                    b.HasIndex("StaffId");

                    b.HasIndex("VisitorId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("iVisitNG.Models.ApprovedAppointment", b =>
                {
                    b.Property<int>("ApproveID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppID");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("StaffID");

                    b.HasKey("ApproveID");

                    b.ToTable("ApprovedAppointment");
                });

            modelBuilder.Entity("iVisitNG.Models.Blacklist", b =>
                {
                    b.Property<int>("blacklistID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Reason");

                    b.Property<string>("StaffID");

                    b.Property<int>("VisitorID");

                    b.HasKey("blacklistID");

                    b.ToTable("Blacklist");
                });

            modelBuilder.Entity("iVisitNG.Models.BuildingCheck", b =>
                {
                    b.Property<int>("CheckID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppID");

                    b.Property<DateTime>("CheckInTime");

                    b.Property<DateTime?>("CheckOutTime");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Status");

                    b.HasKey("CheckID");

                    b.ToTable("BuildingCheck");
                });

            modelBuilder.Entity("iVisitNG.Models.BusySchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("FromDateTime");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("StaffId")
                        .IsRequired();

                    b.Property<DateTime>("ToDateTime");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("BusySchedule");
                });

            modelBuilder.Entity("iVisitNG.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("iVisitNG.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("iVisitNG.Models.DaysOfWeek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Day");

                    b.HasKey("Id");

                    b.ToTable("DaysOfWeek");
                });

            modelBuilder.Entity("iVisitNG.Models.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DivisionName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("iVisitNG.Models.FLoorCheck", b =>
                {
                    b.Property<int>("FloorCheckID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppID");

                    b.Property<DateTime>("CheckInTime");

                    b.Property<DateTime?>("CheckOutTime");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("Floor");

                    b.Property<string>("Status");

                    b.HasKey("FloorCheckID");

                    b.ToTable("FLoorCheck");
                });

            modelBuilder.Entity("iVisitNG.Models.JumpFloor", b =>
                {
                    b.Property<int>("JumpID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppID");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("NewFloor");

                    b.Property<string>("StaffID");

                    b.HasKey("JumpID");

                    b.ToTable("JumpFloor");
                });

            modelBuilder.Entity("iVisitNG.Models.Notifications", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<string>("PostedById")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PostedById");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("iVisitNG.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("DivisionId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("ImagePath")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("StaffId")
                        .IsRequired();

                    b.Property<int>("ZonalOfficeId");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("StaffId");

                    b.HasIndex("ZonalOfficeId");

                    b.ToTable("StaffProfile");
                });

            modelBuilder.Entity("iVisitNG.Models.PurposeOfVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("purpose");

                    b.HasKey("Id");

                    b.ToTable("PurposeOfVisit");
                });

            modelBuilder.Entity("iVisitNG.Models.Security", b =>
                {
                    b.Property<int>("SecID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<DateTime>("RegDate");

                    b.Property<string>("StaffID");

                    b.Property<string>("Status");

                    b.HasKey("SecID");

                    b.ToTable("Security");
                });

            modelBuilder.Entity("iVisitNG.Models.Staff", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsProfileSetUp");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("iVisitNG.Models.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("CountryId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FingerPrint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsBlackListed");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("OfficeAddress")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("RefNumber")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CountryId");

                    b.ToTable("Visitor");
                });

            modelBuilder.Entity("iVisitNG.Models.VisitorItem", b =>
                {
                    b.Property<int>("itemID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppID");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("ItemName");

                    b.Property<string>("SerialNumber");

                    b.Property<int>("VisitorID");

                    b.HasKey("itemID");

                    b.ToTable("VisitorItem");
                });

            modelBuilder.Entity("iVisitNG.Models.ZonalOffice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("ZonalOffice");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("StaffClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("StaffLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("StaffRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("StaffToken");
                });

            modelBuilder.Entity("iVisitNG.Models.Appointment", b =>
                {
                    b.HasOne("iVisitNG.Models.PurposeOfVisit", "Purpose")
                        .WithMany()
                        .HasForeignKey("PurposeOfVisitId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iVisitNG.Models.Staff", "Staff")
                        .WithMany("Visitors")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iVisitNG.Models.Visitor", "Visitor")
                        .WithMany("Staffs")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iVisitNG.Models.BusySchedule", b =>
                {
                    b.HasOne("iVisitNG.Models.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iVisitNG.Models.Notifications", b =>
                {
                    b.HasOne("iVisitNG.Models.Staff", "PostedBy")
                        .WithMany()
                        .HasForeignKey("PostedById")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iVisitNG.Models.Profile", b =>
                {
                    b.HasOne("iVisitNG.Models.Division", "Division")
                        .WithMany()
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iVisitNG.Models.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iVisitNG.Models.ZonalOffice", "ZonalOffice")
                        .WithMany()
                        .HasForeignKey("ZonalOfficeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iVisitNG.Models.Visitor", b =>
                {
                    b.HasOne("iVisitNG.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iVisitNG.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("iVisitNG.Models.Staff")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("iVisitNG.Models.Staff")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iVisitNG.Models.Staff")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("iVisitNG.Models.Staff")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
