using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalMVC.Models
{
    public class RentalSearchVieModel
    {
        public string SearchText { get; set; }
        public List<Rentals> Rental { get; set; }
    }
}