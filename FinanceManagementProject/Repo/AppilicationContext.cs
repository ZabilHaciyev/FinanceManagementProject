using FinanceManagementProject.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace FinanceManagementProject.Repo
{
    public class AppilicationContext : DbContext
    {
        public DbSet<User> Users{ get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Tax> Taxes{ get; set; }
        public DbSet<CompunalExpenses>  CompunalExpenses { get; set; }
        public DbSet<Income>  Incomes{ get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("C:\\Users\\zabil\\source\\repos\\FinanceManagementProject\\FinanceManagementProject\\appSettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            


            //modelBuilder.Entity<Employee>().Property(e => e.Image).HasColumnType("");
        }
    }
}