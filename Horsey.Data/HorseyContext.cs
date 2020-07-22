using Horsey.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Data;

namespace Horsey.Data
{
    public class HorseyContext : DbContext
    {
        public DbSet<Race> Races { get; set; }
        public DbSet<Horse> Horses { get; set; }
        public DbSet<Standing> Standings { get; set; }
        public DbSet<Health> Prognosis { get; set; }

        public static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder =>
            {
                builder
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name 
                    && level == LogLevel.Information)
                .AddConsole();
            });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(ConsoleLoggerFactory)
                .UseSqlServer("Data Source = localhost; Initial Catalog = Horsey; Integrated Security = True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Standing>()
            //    .HasKey(s => new { s.RaceId, s.HorseId });            
            //modelBuilder.Entity<Standing>()
                //.HasNoKey()
                //.HasOne(s => s.Race)
                //.WithMany(r => r.Standings)
                //.HasForeignKey(s => s.RaceId)
                //.HasPrincipalKey(x=>x.Id);

        }
    }
}
