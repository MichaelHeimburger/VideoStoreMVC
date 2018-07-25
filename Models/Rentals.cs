using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalMVC.Models
{
    public class Rentals
    {
        public int ID { get; set; }
        public DateTime RentalDate { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer {get;set;}

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}