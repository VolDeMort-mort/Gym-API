using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Data
{
    public class SportLifeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<TrainingRecord> TrainingRecords { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Hall> Halls { get; set; }

        public SportLifeDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SLDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Додавання типів користувачів
            modelBuilder.Entity<UserType>().HasData(
                new UserType { Id = 1, Name = "Admin" },
                new UserType { Id = 2, Name = "Trainer" },
                new UserType { Id = 3, Name = "Client" }
            );

            // Додавання користувачів
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Alice Johnson", Email = "alice@example.com", Phone = "111222333", UserTypeId = 3, RegistrationDate = new DateTime(2025, 3, 10), SubscriptionStatus = "Active" },
                new User { Id = 2, Name = "Bob Williams", Email = "bob@example.com", Phone = "444555666", UserTypeId = 3, RegistrationDate = new DateTime(2025, 2, 20), SubscriptionStatus = "Inactive" },
                new User { Id = 3, Name = "Charlie Brown", Email = "charlie@example.com", Phone = "777888999", UserTypeId = 1, RegistrationDate = new DateTime(2025, 1, 15), SubscriptionStatus = "Active" }
            );

            // Додавання тренерів
            modelBuilder.Entity<Coach>().HasData(
                new Coach { Id = 1, Name = "Chris Evans", Specialization = "Cardio", Experience = 6, Schedule = "Monday-Friday", Rating = 4.7 },
                new Coach { Id = 2, Name = "Emma Watson", Specialization = "Yoga", Experience = 4, Schedule = "Tuesday-Thursday", Rating = 4.8 }
            );

            // Додавання тренувань
            modelBuilder.Entity<Training>().HasData(
                new Training { Id = 1, Name = "HIIT Workout", Category = "Group", CoachId = 1, HallId = 1, Date = new DateTime(2025, 4, 18), Duration = 60, MaxParticipants = 20 },
                new Training { Id = 2, Name = "Yoga Basics", Category = "Group", CoachId = 2, HallId = 2, Date = new DateTime(2025, 4, 19), Duration = 90, MaxParticipants = 15 },
                new Training { Id = 3, Name = "Boxing Training", Category = "Individual", CoachId = 1, HallId = 3, Date = new DateTime(2025, 4, 20), Duration = 45, MaxParticipants = 1 }
            );

            // Додавання залів
            modelBuilder.Entity<Hall>().HasData(
                new Hall { Id = 1, Number = 101, Equipment = "Mats, Dumbbells", Capacity = 20, Availability = true },
                new Hall { Id = 2, Number = 102, Equipment = "Punching Bags, Gloves", Capacity = 15, Availability = true },
                new Hall { Id = 3, Number = 103, Equipment = "Treadmills, Weights", Capacity = 10, Availability = false }
            );

            // Додавання розкладу
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule { Id = 1, Date = new DateTime(2025, 4, 18), Time = new DateTime(2025, 4, 18, 9, 0, 0), TrainingId = 1, CoachId = 1, HallId = 1, AvailableSpots = 10 },
                new Schedule { Id = 2, Date = new DateTime(2025, 4, 19), Time = new DateTime(2025, 4, 19, 14, 0, 0), TrainingId = 2, CoachId = 2, HallId = 2, AvailableSpots = 15 },
                new Schedule { Id = 3, Date = new DateTime(2025, 4, 20), Time = new DateTime(2025, 4, 20, 16, 0, 0), TrainingId = 3, CoachId = 1, HallId = 3, AvailableSpots = 1 }
            );

            // Додавання абонементів
            modelBuilder.Entity<Subscription>().HasData(
                new Subscription { Id = 1, UserType = "Monthly", Price = 50.00M, DurationInDays = 30, AvailableServices = "Gym, Yoga, Swimming" },
                new Subscription { Id = 2, UserType = "Annual", Price = 500.00M, DurationInDays = 365, AvailableServices = "All facilities, VIP training" },
                new Subscription { Id = 3, UserType = "One-Time", Price = 10.00M, DurationInDays = 1, AvailableServices = "Single training session" }
            );

            // Додавання оплат
            modelBuilder.Entity<Payment>().HasData(
                new Payment { Id = 1, UserId = 1, Amount = 50.00M, UserType = "Subscription", Date = new DateTime(2025, 4, 5) },
                new Payment { Id = 2, UserId = 2, Amount = 500.00M, UserType = "Annual Subscription", Date = new DateTime(2025, 3, 1) },
                new Payment { Id = 3, UserId = 3, Amount = 10.00M, UserType = "One-Time Training", Date = new DateTime(2025, 4, 12) }
            );

            // Додавання записів на тренування
            modelBuilder.Entity<TrainingRecord>().HasData(
                new TrainingRecord { Id = 1, ClientId = 1, TrainingId = 1, Status = "Registered" },
                new TrainingRecord { Id = 2, ClientId = 2, TrainingId = 2, Status = "Cancelled" },
                new TrainingRecord { Id = 3, ClientId = 3, TrainingId = 3, Status = "Attended" }
            );

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Training)
                .WithMany(t => t.Schedules)
                .HasForeignKey(s => s.TrainingId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Coach)
                .WithMany(c => c.Schedules)
                .HasForeignKey(s => s.CoachId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Hall)
                .WithMany(h => h.Schedules)
                .HasForeignKey(s => s.HallId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
