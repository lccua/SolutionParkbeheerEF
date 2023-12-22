using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Context
{
    public class ParkbeheerContext : DbContext
    {

        public DbSet<HuisEF> Huizen { get; set; }

        public DbSet<HuurderEF> Huurders { get; set; }

        public DbSet<ParkEF> Parken { get; set; }

        public DbSet<HuurcontractEF> Huurcontracten { get; set; }

        public ParkbeheerContext()
        {
            // Configure the context to not track any entities by default
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=ParkDB;Integrated Security=True;Trust Server Certificate=True");

            // Enable sensitive data logging
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.LogTo(Console.WriteLine);
        }




    }
}
