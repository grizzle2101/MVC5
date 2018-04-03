using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    //Task 2 - Create Folder Viewmodel & Add ViewModel classs.
    //Convention Dictates we have "ViewmModel" in the Name
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}