﻿using Favtick.Core.Entities;
using Favtick.Core.Entities.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Favtick.Core.Migrations
{
    public class FavtickContext : DbContext
    {
        
        public FavtickContext(DbContextOptions options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>()
             .HasOne<Candidate>()
             .WithMany()
             .HasForeignKey("CandidateId")
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();
        }

    }
}
