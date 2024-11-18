using InvestmentsCoreApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace IvestmentsCoreApi.Infra
{

    public class InvestmentsDbContext : DbContext
    {
        public InvestmentsDbContext(DbContextOptions<InvestmentsDbContext> options) : base(options) { }

        public DbSet<Funds> Funds { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Investments> Investments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensure EF Core recognizes the primary key for each entity
            modelBuilder.Entity<Funds>()
                .HasKey(f => f.FundID);

            modelBuilder.Entity<Customers>()
                .HasKey(c => c.CustomerID);

            modelBuilder.Entity<Investments>()
                .HasKey(i => i.InvestmentID);



           

        }
    }
}
