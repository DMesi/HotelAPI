using HotelAPI.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // nuget

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Data
{
    public class DataBase : IdentityDbContext<ApiUser> // DODAJEMO
    {
       public DataBase(DbContextOptions options):base(options)
        {
                
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  //DODAJEMO
       
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new HotelConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());

        }      
    }
}
