using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riddles.DAL.Entities;

namespace Riddles.DAL
{
    public class ApplicationContext : DbContext
    {

        private readonly string connectionString;

        public DbSet<User> Users { get; set; }

        public DbSet<GameSession> GameSessions { get; set; }

        public DbSet<GameSessionAnswerHistory> GameSessionAnswerHistories { get; set; }

        public DbSet<GameSessionUseHintHistory> GameSessionUseHintHistories { get; set; }

        public DbSet<Hint> Hints { get; set; }

        public DbSet<Level> Levels { get; set; }

        public DbSet<Riddle> Riddles { get; set; }

        public DbSet<XrefGameSessionUser> XrefGameSessionUsers { get; set; }

        public ApplicationContext(string connectionString) : base()
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<XrefGameSessionUser>()
                .HasKey(x => new { x.GameSessionID, x.UserId });

            modelBuilder.Entity<XrefGameSessionUser>()
                .HasOne(x => x.GameSession)
                .WithMany(xgu => xgu.XrefGameSessionUsers)
                .HasForeignKey(x => x.GameSessionID);

            modelBuilder.Entity<XrefGameSessionUser>()
                .HasOne(x => x.User)
                .WithMany(xgu => xgu.XrefGameSessionUsers)
                .HasForeignKey(x => x.UserId);
        }
    }
}
