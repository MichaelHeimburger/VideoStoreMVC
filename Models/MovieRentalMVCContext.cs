using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieRentalMVC.Models
{
    public class MovieRentalMVCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MovieRentalMVCContext() : base("name=MovieRentalMVCContext")
        {
        }

        public System.Data.Entity.DbSet<MovieRentalMVC.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<MovieRentalMVC.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<MovieRentalMVC.Models.Rentals> Rentals { get; set; }
    }
}
