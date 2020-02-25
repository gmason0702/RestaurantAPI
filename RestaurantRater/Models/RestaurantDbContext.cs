using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext() :base("DefaultConnection")//connects to the name of the DbContext, which connects to the local database
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }//DbSet requires taking in a TEntity class
    }
}