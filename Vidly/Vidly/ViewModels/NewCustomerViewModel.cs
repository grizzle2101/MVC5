using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewCustomerViewModel
    {
        //Task 2 - Update View Model
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set;}
    }
}