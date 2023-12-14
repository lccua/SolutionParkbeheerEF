using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Context
{
    public class ParkContext : DbContext
    {

        public DbSet<HuisEF> Huizen { get; set; }

        public DbSet<HuurderEF> Huurders { get; set; }

        public DbSet<ParkEF> Categories { get; set; }

        public DbSet<HuurcontractEF> Huurcontracten { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=ParkDB;Integrated Security=True;Trust Server Certificate=True");
            
        }


    }
}
