using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>().ToTable("Admins");
        modelBuilder.Entity<Trainer>().ToTable("Trainers");
        modelBuilder.Entity<Trainee>().ToTable("Trainees");

        base.OnModelCreating(modelBuilder);
    }
}