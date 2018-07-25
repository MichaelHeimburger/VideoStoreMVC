using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalMVC.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Movie> CurrentRentedMovies { get; set; }
        public List<Movie> PastRentedMovies { get; set; }
    }
}