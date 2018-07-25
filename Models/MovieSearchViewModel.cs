using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalMVC.Models
{
    public class MovieSearchViewModel
    {
        public string SearchText { get; set; }
        public List<Movie> Result {get;set;}
    }
}