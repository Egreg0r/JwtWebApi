using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using JwtWebApi.Data;


namespace JwtWebApi.Model
{
    public class BaseContext : DbContext
    {
        public DbSet<LoginModel> loginModels { get; set; }
        public  DbSet<Ticket> tickets { get; set; }

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginModel>().HasData(FakeDataFactory.defLoginModels);
            modelBuilder.Entity<Ticket>().HasData(FakeDataFactory.defTickets);

            //base.OnModelCreating(modelBuilder);
            
        }

    }
}
