using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    //Task 5 - Create Rental DTO
    public class RentalDTO
    {
        public int CustomerID { get; set; }
        public List<int> MovieIds { get; set; }
    }
}