using CommunityManagerDashBoard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityManagerDashBoard.Models
{
    public class Resident : IModel
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName {get;set;}
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Lot Name")]
        public int LotNumber { get; set; }
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        
    }
}
