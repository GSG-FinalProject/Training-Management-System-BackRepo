using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TMS.Domain.Entities;

namespace TMS.Infrastructure.DbContexts;
public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<Domain.Entities.Task> Tasks { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<TrainingField> TrainingFields { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Submission> Submissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>().ToTable("Admins");
        modelBuilder.Entity<Trainer>().ToTable("Trainers");
        modelBuilder.Entity<Trainee>().ToTable("Trainees");
        modelBuilder.Entity<Domain.Entities.Task>().ToTable("Tasks");
        modelBuilder.Entity<Course>().ToTable("Courses");
        modelBuilder.Entity<TrainingField>().ToTable("TrainingFields");
        modelBuilder.Entity<Feedback>().ToTable("Feedbacks");

        modelBuilder.Entity<Submission>()
          .HasOne(s => s.Trainee)
          .WithMany(t => t.Submissions)
          .HasForeignKey(s => s.TraineeId)
          .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Submission>()
            .HasOne(s => s.Task)
            .WithMany(t => t.Submissions)
            .HasForeignKey(s => s.TaskId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
