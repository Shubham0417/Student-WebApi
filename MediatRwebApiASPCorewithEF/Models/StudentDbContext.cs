using Microsoft.EntityFrameworkCore;

namespace MediatRwebApiASPCorewithEF.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions Options) : base(Options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
        .HasKey(s => s.Id);

            modelBuilder.Entity<Address>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Address>()
                .HasOne(s => s.Student)
                .WithMany(a => a.Addresses)
                .HasForeignKey(a => a.StudentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>().HasData(
    new Student { Id = 1, Name = "Rahul", Gender = "Male", Standard = 10},
    new Student { Id = 2, Name = "Anita", Gender = "Female", Standard = 9}
);

            modelBuilder.Entity<Address>().HasData(
                // Rahul – Permanent
                new Address
                {
                    Id = 1,
                    StudentId = 1,
                    HouseNo = "12A",
                    Street = "MG Road",
                    District = "Pune",
                    State = "Maharashtra",
                    IsPermanent = "Y"
                },
                // Rahul – Temporary
                new Address
                {
                    Id = 2,
                    StudentId = 1,
                    HouseNo = "45B",
                    Street = "Station Road",
                    District = "Mumbai",
                    State = "Maharashtra",
                    IsPermanent = "N"
                },
                // Anita – Permanent
                new Address
                {
                    Id = 3,
                    StudentId = 2,
                    HouseNo = "88C",
                    Street = "Park Street",
                    District = "Kolkata",
                    State = "West Bengal",
                    IsPermanent = "Y"
                }
            );

        }
    }
}
