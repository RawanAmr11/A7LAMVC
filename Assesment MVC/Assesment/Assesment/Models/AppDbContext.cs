﻿using Assesment.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Tasks> Tasks { get; set; }

        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
                .HasOne(x => x.Project)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.ProjectID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tasks>()
                .HasOne(x => x.TeamMember)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.TeamMemberID)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
