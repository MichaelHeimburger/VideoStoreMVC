using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalMVC.Models
{
    public class SearchMasterViewModel
    {
        public string SearchText { get; set; }
        public List<Movie> MovieResult { get; set;}
        public List<Rentals> RentalResult { get; set; }
        public List<Customer> CustomerReuslt { get; set; }

    }
}