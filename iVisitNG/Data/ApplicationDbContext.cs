using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using iVisitNG.Models;
using Microsoft.AspNetCore.Identity;
using iVisitNG.Models.ViewModels;

namespace iVisitNG.Data
{
    public class ApplicationDbContext : IdentityDbContext<Staff>
    {
        public DbSet<Profile> StaffProfile { get; set; }
        public DbSet<ZonalOffice> ZonalOffice { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Visitor> Visitor { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<BusySchedule> BusySchedule { get; set; }
        public DbSet<AppointmentDateTime> AppointmentDate { get; set; }
        public DbSet<PurposeOfVisit> PurposeOfVisit { get; set; }
        public DbSet<Division> Division { get; set; }

        public DbSet<Staff> Staff { get; set; }

        public DbSet<DaysOfWeek> DaysOfWeek { get; set; }
        public DbSet<Notifications> Notification { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Staff>().ToTable("Staff");
            builder.Entity<IdentityRole>().ToTable("Role");

            builder.Entity<IdentityUserRole<string>>().ToTable("StaffRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("StaffClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("StaffLogin");

            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("StaffToken");

            //builder.Entity<Appointment>().HasKey()
        }

    }

}
