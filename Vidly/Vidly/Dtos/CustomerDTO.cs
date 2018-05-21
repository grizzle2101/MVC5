using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    //Task 1 - Create CustomerDTO
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //Exclude Other Domain Model Items:
        //public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        //[Min18YearIfAMember]
        public DateTime? Birthdate { get; set; }
    }

}